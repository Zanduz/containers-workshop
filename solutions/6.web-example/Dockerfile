# Trin 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopiér csproj og genskab afhængigheder
COPY *.csproj ./
RUN dotnet restore

# Kopiér resten og byg
COPY . ./
RUN dotnet publish -c Release -o out

# Trin 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080

COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "HelloWorldApp.dll"]
