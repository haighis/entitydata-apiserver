docker build . -t dockerdotnetapi:5


docker run -p 9083:5005 -d dockerdotnetapi:5

docker run --name dockerdotnetapi -e "ASPNETCORE_URLS=http://+:5000" -p 8081:5000 -d dockerdotnetapi:1


docker build -f "C:\Projects\Fluence\Fluence\docker-dotnet-api\Dockerfile" -t fluence/docker-dotnet-api-new "C:\Projects\Fluence\Fluence"

docker run --name docker-dotnet-api-new -e "ASPNETCORE_URLS=http://+:5000" -p 8081:5000 -d fluence/docker-dotnet-api-new


http://localhost:8081/api/weather


docker build -f "C:\Projects\Fluence\Fluence\Fluence.Api.WebApiTest\Dockerfile" -t fluence/newnewnew:6 --target base "C:\Projects\Fluence\Fluence"  

docker run -dt -v "C:\Users\John Haigh\AppData\Roaming\Microsoft\UserSecrets:/root/.microsoft/usersecrets:ro" -v "C:\Users\John Haigh\.nuget\packages\:/root/.nuget/fallbackpackages3" -v "C:\Program Files (x86)\Microsoft Visual Studio\Shared\NuGetPackages:/root/.nuget/fallbackpackages" -v "C:\Program Files\dotnet\sdk\NuGetFallbackFolder:/root/.nuget/fallbackpackages2" -e "NUGET_PACKAGES=/root/.nuget/fallbackpackages3" -e "NUGET_FALLBACK_PACKAGES=/root/.nuget/fallbackpackages;/root/.nuget/fallbackpackages2;/root/.nuget/fallbackpackages3" -p 5000:80 -d fluence/newnewnew:6