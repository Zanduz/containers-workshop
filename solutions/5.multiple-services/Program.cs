using System;
using Npgsql;

class Program
{
  static void Main(string[] args)
  {
    // Læs forbindelsesstreng fra miljøvariabel
    var connString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

    using var conn = new NpgsqlConnection(connString);
    conn.Open();

    // Simpel forespørgsel (laver en tabel og indsætter en række)
    using var cmd = new NpgsqlCommand(@"
      CREATE TABLE IF NOT EXISTS greetings (id SERIAL PRIMARY KEY, text TEXT);
      INSERT INTO greetings (text) VALUES ('Hello, World from PostgreSQL!');
      SELECT text FROM greetings;
    ", conn);

    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      Console.WriteLine(reader.GetString(0));
    }
  }
}
