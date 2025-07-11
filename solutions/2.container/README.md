# Solution 2: Containerize your application

Reusing everything from `1.helloworld`, adding a `Dockerfile` with the content below, enables us to containerize our application.

Dockerfile:

```Dockerfile
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest and build
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "HelloWorldApp.dll"]
```

To create the container image, run `sudo docker build --tag hello-dotnet .`.

The container image can be listed with `sudo docker image ls`. The image got tagged with the version `latest` by default. Changing the image version is done by adding colon+version to the `--tag` option like this `sudo docker build --tag hello-dotnet:1.0.0 .`, where the version is `1.0.0`.

It is possible to add multiple versions/tags to the same image. This is done with `sudo docker tag hello-dotnet:1.0.0 hello-dotnet:1.0` which tags the `hello-dotnet:1.0.0` with the version `1.0`. Now `sudo docker image ls` shows both image versions, and importantly, they have the same `IMAGE ID`. I.e. they point to exactly the same image.

To run the container, run the command `sudo docker run hello-dotnet`.

To list all containers, including stopped/exited ones, run `sudo docker ps -a`.

## Navigation

Exercise: [Exercise 2](../../exercise-2.md)  
Next exercise: [Exercise 3](../../exercise-3.md)  
Previous exercise: [Exercise 1](../../exercise-1.md)  
Main readme: [Main readme](../../README.md)
