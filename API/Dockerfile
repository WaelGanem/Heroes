FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# Copy and restore the csproj first to enable efficient caching of packages
COPY *.csproj .
RUN dotnet restore

# Copy everything else
COPY . .

# Build and publish the release version
RUN dotnet publish -c Release -o publish 

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=base ./HEROESAPI/bin/Release/net8.0 .
ENTRYPOINT ["dotnet", "HEROESAPI.dll"] 
