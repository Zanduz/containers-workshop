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
