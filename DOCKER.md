
# Environment Variables
- CONNECTIONSTRINGS__WEBAPI_DB="Server=host.docker.internal;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres"

# Build
docker build . -t entitydata-api:1

docker run --rm -v /path/to/my_awesome_app:/source -v /path/to/my_awesome_app/tarballs:/stage/tarballs edib/edib-tool:1.0


docker run -p 5009:4000 -d hello

docker build . -t hello

docker run -p 5009:4000 -d dempapi

docker build . -t dempapi


docker run -p 5009:4000 -d appbuildernew

docker build . -t appbuildernew


 mix dockerize.init --no-phoenix-assets --elixir-version 1.14

docker 

# Run
docker run -p 9083:5005 -e CONNECTIONSTRINGS__WEBAPI_DB="Server=host.docker.internal;Port=5433;Database=mngo-builder;User Id=postgres;Password=postgres" -d entitydata-api:6


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