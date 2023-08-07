using System;
using System.Collections.Generic;

namespace entitydata.webapi;

public class DataWriteRequest
{
    public InsertItem Insert { get; set; }
    public InsertItem Update { get; set; }
}

public class InsertItem
{
    public string Table { get; set; }
    public string[] Columns { get; set; }
    public List<List<string>> Data { get; set; }
    //public object[][] Data { get; set; }
}

public class DataItem
{
    public object[] Row { get; set; }
}

