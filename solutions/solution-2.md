
# Solution 2: Containerize your application

# .NET solution

```bash
$ mkdir -p ~/exercise-2
$ cd ~/exercise-2

# Create a .NET hello-world app
$ cat <<EOF > Helloworld.cs
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello from Docker (.NET)!");
    }
}
EOF

# Create the Dockerfile
$ cat <<EOF > Dockerfile
# Build stage using dotnet sdk image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage using slimmer runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "exercise-2-dotnet.dll"]
EOF

# Build the image
$ sudo docker build -t hello-dotnet .

# Run the container
$ sudo docker run hello-dotnet

# List all containers, including stopped/exited ones.
$ sudo docker ps -a
```

# Python solution

```bash
# Create the exercise directory
$ mkdir -p ~/exercise-2
$ cd ~/exercise-2

# Create a Python hello-world app
$ cat <<EOF > app.py
print("Hello from Docker!")
EOF

# Create the Dockerfile
$ cat <<EOF > Dockerfile
FROM python:3-slim
WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
EOF

# Build the image
$ sudo docker build -t hello-python .

# Check the local registry
$ sudo docker images

# Run the container
$ sudo docker run hello-python

# List all containers, including stopped/exited ones.
$ sudo docker ps -a
```

Link to exercise: [Exercise 2](../exercise-2.md)  
Next exercise: [Exercise 3](../exercise-3.md)  
Previous exercise: [Exercise 1](../exercise-1.md)  
Main readme: [Main readme](../README.md)
