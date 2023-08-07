using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.IO;
using Newtonsoft.Json;
using Npgsql;
using System.Net.Http;

namespace entitydata.webapi.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class WriteController : ControllerBase
    {
        private readonly ILogger<WriteController> _logger;

        public WriteController(ILogger<WriteController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Get([FromBody] DataWriteRequest request)
        {
            //TODO move this to another layer of abstraction
            using (var db = PostgresQueryFactory())
            {
                if (request.Insert != null) {
                    db.Query(request.Insert.Table).Insert(request.Insert.Columns, request.Insert.Data);
                }

                //if (request.Update != null) {
                //    db.Query(request.Update.Table).Update(request.Update.Columns, request.Update.Data);
                //}
            }
        }

        private static QueryFactory PostgresQueryFactory()
        {
            var connection = new NpgsqlConnection("Server=host.docker.internal;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres");
            var compiler = new PostgresCompiler();
            var db = new QueryFactory(connection, compiler);
            return db;
        }
    }

