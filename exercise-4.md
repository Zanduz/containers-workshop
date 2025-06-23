# Exercise 4: Orchestrate development environment

## Objective

Orchestrate development of application and container with docker compose.

## Description

Docker compose can be used to remove a lot of boiler plate commands, and manage both build and execution of multiple services.

To begin with we just wrap our newly created container in a docker compose configuration and test it.

The initial docker compose file `docker-compose.yml` looks like this:

## Steps

1. Create a `docker-compose.yml` file.
2. Add a service `hello-dotnet`.
3. Specify that this service is built from local source with our `Dockerfile` ([see `services` section](https://docs.docker.com/compose/gettingstarted/#step-2-define-services-in-a-compose-file)).
4. Specify the running containers name.
5. Specify the name of the image being built.
6. Test the application with `sudo docker compose up --build`.
7. Check the containers in the compose-deployment with `sudo docker compose ps -a`.
8. Make sure to bring down the deployment again with `sudo docker compose down` when done.
9. Check that the containers in the compose-deployment have been removed, again with `sudo docker compose ps -a`.

## Navigation

Solution: [Solution 4](./solutions/4.docker-compose/README.md)  
Next exercise: [Exercise 5](./exercise-5.md)  
Previous exercise: [Exercise 3](./exercise-3.md)  
Main readme: [Main readme](./README.md)
