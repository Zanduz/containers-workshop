# Solution 6: Add a front end

Create the folder `frontend` and add a new Node.js front end application in it.

Add a `frontend/Dockerfile` specification of the front end image.

```Dockerfile
FROM node:20
WORKDIR /app

COPY . ./
RUN npm install

EXPOSE 3000

ENTRYPOINT ["node", "index.js"]
```

Define dependencies in `frontend/package.json`

```json
{
  "name": "frontend",
  "version": "1.0.0",
  "main": "index.js",
  "dependencies": {
    "axios": "^1.6.7",
    "express": "^4.18.4"
  }
}
```

Create the Node.js application in `frontend/index.js`

```javascript
const express = require("express");
const axios = require("axios");
const app = express();

app.get("/", async (req, res) => {
  try {
    const response = await axios.get("http://hello-dotnet:8080");
    res.setHeader("Content-Type", "application/text");
    res.send(`Frontend says: "${JSON.stringify(response.data, null, 2)}"`);
  } catch (err) {
    console.error("Error contacting backend:", err.message);
    res.status(500).send("Error calling backend");
  }
});

app.listen(3000, () => {
  console.log("Frontend listening on port 3000");
});
```

Add the new front end service to the `docker-compose.yml`

```Dockerfile
services:
  frontend:
    build:
      context: ./frontend
    ports:
    - "3000:3000"
    depends_on:
    - hello-dotnet
    networks:
    - local_network
```

Make sure that the C# project file `HelloWorldApp.csproj` is a web project

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Npgsql" Version="9.0.3" />
  </ItemGroup>
</Project>
```

Make sure that the C# program `Program.cs` implements a web service that calls the database

```C#
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (var conn = new NpgsqlConnection(Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")))
{
    await conn.OpenAsync();
    var ensureCmd = new NpgsqlCommand(@"
        CREATE TABLE IF NOT EXISTS greetings (
            id SERIAL PRIMARY KEY,
            text TEXT NOT NULL
        );
        INSERT INTO greetings (text) VALUES ('Hello from PostgreSQL') ON CONFLICT DO NOTHING;
    ", conn);
    await ensureCmd.ExecuteNonQueryAsync();
}

app.MapGet("/", async (HttpContext context) =>
{
  var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
  var greetings = new List<Greeting>();

  using var conn = new NpgsqlConnection(connectionString);
  await conn.OpenAsync();

  var cmd = new NpgsqlCommand("SELECT id, text FROM greetings", conn);
  using var reader = await cmd.ExecuteReaderAsync();

  while (await reader.ReadAsync())
  {
    greetings.Add(new Greeting
    {
      Id = reader.GetInt32(0),
      Text = reader.GetString(1)
    });
  }

  context.Response.ContentType = "application/json";
  await context.Response.WriteAsync(JsonSerializer.Serialize(greetings));
});

app.Run();

public class Greeting
{
  public int Id { get; set; }
  public string Text { get; set; }
}
```

## Navigation

Link to exercise: [Exercise 6](../../exercise-6.md)  
Previous exercise: [Exercise 5](../../exercise-5.md)  
Main readme: [Main readme](../../README.md)
