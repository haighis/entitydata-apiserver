
# Environment Variables
- CONNECTIONSTRINGS__WEBAPI_DB="Server=host.docker.internal;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres"

# Build
docker build . -t entitydata-api:1

# Run
docker run -p 9083:5005 -e CONNECTIONSTRINGS__WEBAPI_DB="Server=host.docker.internal;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres" -d entitydata-api:6

# Access
- Sanity - http://localhost:9083/api/weather


## POST - Read Entity
Read - http://localhost:9083/api/read

`
{
    "dataTableQueryItems": 
    [
        {
            "table": "posts",
            "columns": ["title", "id", "description"]
        },{
            "table": "categories",
            "columns": ["title", "id"]
        }
    ]
}
`