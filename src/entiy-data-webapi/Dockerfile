# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# sample change for ci server.
WORKDIR /src
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /src/out .

CMD ["./entitydata.webapi"]
#ENTRYPOINT [ "dotnet", "docker-dotnet-api.dll" ]

