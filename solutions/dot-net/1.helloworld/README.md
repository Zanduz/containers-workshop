# Solution 1: Prepare your own application or bring your own

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

Link to exercise: [Exercise 1](../../../exercise-1.md)  
Next exercise: [Exercise 2](../../../exercise-2.md)  
Previous exercise: [Exercise 0](../../../exercise-0.md)  
Main readme: [Main readme](../../../README.md)
