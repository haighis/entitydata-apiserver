using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.IO;
using Newtonsoft.Json;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace entitydata.webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReadController : ControllerBase
{
    private readonly ILogger<ReadController> _logger;
    private readonly IConfiguration _config;

    public ReadController(ILogger<ReadController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    // Data Model
    // Row of columns
    // array of arrays

    [HttpPost]
    public DatasetResponse Get([FromBody] DatasetQuery datasetRequest)
    { 
        var list = new List<DataTable>();
        var connectionString = _config.GetConnectionString("WEBAPI_DB");    
        //TODO move this to another layer of abstraction
        using (var db = PostgresQueryFactory(connectionString)) 
        {
            foreach (var dataTable in datasetRequest.DataTableQueryItems)
            {
                // Get data
                var query = (dataTable.Columns != null && dataTable.Columns.Count > 0) ?
                    db.Query(dataTable.Table).Select(dataTable.Columns.ToArray()) : db.Query(dataTable.Table);

                var tableItems = query.Clone().Get();
                Console.WriteLine(JsonConvert.SerializeObject(tableItems, Formatting.Indented));

                var dataViewItem = new DataTable
                {
                    Columns = dataTable.Columns,
                    Table = dataTable.Table,
                    Rows = tableItems
                };

                list.Add(dataViewItem);
            }
        }

        // Hydrate return object
        var dataviewRequest = new DatasetResponse
        {
            DataTables = list
        };

        return dataviewRequest;
    }

    private static QueryFactory PostgresQueryFactory(string connectionString)
    {
        //var my = ConnectionManager.GetConnectionString("DefaultConnection");
        //Configration.GetConnectionString("WEBAPI_DB")
        //var connection = new NpgsqlConnection("Server=host.docker.internal;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres");
        var connection = new NpgsqlConnection(connectionString);
        //Server=localhost;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres;
        //var connection = new SqlConnection("Data Source=MyDb;User Id=User;Password=TopSecret");
        var compiler = new PostgresCompiler();
        var db = new QueryFactory(connection, compiler);
        return db;
    }

    //private static QueryFactory SqlLiteQueryFactory()
    //{
        
    //    var compiler = new SqliteCompiler();
    //    var connection = new SQLiteConnection("Data Source=Demo.db");

    //    var db = new QueryFactory(connection, compiler);

    //    db.Logger = result =>
    //    {
    //        Console.WriteLine(result.ToString());
    //    };
            
    //    if (!System.IO.File.Exists("Demo.db"))
    //    {
    //        Console.WriteLine("db not exists creating db");

    //        SQLiteConnection.CreateFile("Demo.db");

    //        db.Statement("create table accounts(id integer primary key autoincrement, name varchar, currency_id varchar, balance decimal, created_at datetime);");
    //        for (var i = 0; i < 10; i++)
    //        {
    //            db.Statement("insert into accounts(name, currency_id, balance, created_at) values(@name, @currency, @balance, @date)", new
    //            {
    //                name = $"Account {i}",
    //                currency = "USD",
    //                balance = 100 * i * 1.1,
    //                date = DateTime.UtcNow,
    //            });
    //        }

    //    }

    //    return db;

    //}

    private static QueryFactory SqlServerQueryFactory()
    {
        var compiler = new PostgresCompiler();
        var connection = new SqlConnection(
            "Server=tcp:localhost,1433;Initial Catalog=Lite;User ID=sa;Password=P@ssw0rd"
        );

        var db = new QueryFactory(connection, compiler);

        db.Logger = result =>
        {
            Console.WriteLine(result.ToString());
        };

        return db;
    }
}

