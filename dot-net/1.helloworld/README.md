# Simple hello world aplication

Project is created with `sudo docker run --workdir /HelloWorldApp --volume $PWD:/HelloWorldApp:rw mcr.microsoft.com/dotnet/sdk:8.0 dotnet new console`.

The file `Program.cs` is changed to contain the following:

```C#
using System;

class Program
{
  static void Main(string[] args)
  {
    Console.WriteLine("Hello, World!");
  }
}
```

The program is built and run with `sudo docker run --workdir /HelloWorldApp --volume $PWD:/HelloWorldApp:rw mcr.microsoft.com/dotnet/sdk:8.0 dotnet run`.
