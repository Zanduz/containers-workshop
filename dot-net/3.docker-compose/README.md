# Local orchestration

Docker compose can be used to remove a lot of boiler plate commands, and manage both build and execution of multiple services.

To begin with we just wrap our newly created container in a docker compose configuration and test it.

The initial docker compose file `docker-compose.yml` looks like this:

```yaml
services:
  hello-dotnet:
    build:
      context: .
      dockerfile: Dockerfile
    container_name: hello-dotnet
    image: hello-dotnet:latest
```

This time, the application is built with `sudo docker compose build` and run with `sudo docker compose up`.
Build and run can be combined with `sudo docker compose up --build`.
