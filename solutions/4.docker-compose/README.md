# Solution 4: Orchestrate development environment

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

Check the containers in the compose-deployment with `sudo docker compose ps -a`.

Bring down the deployment again with `sudo docker compose down`.

Check that the containers in the compose-deployment have been removed, again with `sudo docker compose ps -a`.

## Navigation

Link to exercise: [Exercise 4](../../exercise-4.md)  
Next exercise: [Exercise 5](../../exercise-5.md)  
Previous exercise: [Exercise 3](../../exercise-3.md)  
Main readme: [Main readme](../../README.md)
