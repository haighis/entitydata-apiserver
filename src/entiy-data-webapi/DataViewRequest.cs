using System;
using System.Collections.Generic;

namespace entitydata.webapi;

    public class DatasetQuery //DatasetRequest
    {
        public DataTableQueryItem[] DataTableQueryItems { get; set; }
    }

    public class DataTableQueryItem
    {
        public string Table { get; set; }
        public List<string> Columns { get; set; }
    }

    public class DatasetResponse
    {
        public List<DataTable> DataTables { get; set; }
    }

    public class DataTable
    {
        public string Table { get; set; }
        public List<string> Columns { get; set; }
        public IEnumerable<dynamic> Rows { get; set; }
    }

