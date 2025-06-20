# Solution 1: Prepare your own application or bring your own

The project and filesystem is created with `sudo docker run --workdir /HelloWorldApp --volume $PWD:/HelloWorldApp:rw mcr.microsoft.com/dotnet/sdk:8.0 dotnet new console`.

You might need to change ownership on the created files. To do that, run `sudo chown -R <username>:<username>`.

Change the file `Program.cs` to contain the following:

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

Build and run the container with `sudo docker run --workdir /HelloWorldApp --volume $PWD:/HelloWorldApp:rw mcr.microsoft.com/dotnet/sdk:8.0 dotnet run`.

Link to exercise: [Exercise 1](../../../exercise-1.md)  
Next exercise: [Exercise 2](../../../exercise-2.md)  
Previous exercise: [Exercise 0](../../../exercise-0.md)  
Main readme: [Main readme](../../../README.md)
