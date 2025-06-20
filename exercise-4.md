# Exercise 4: Orchestrate development environment

## Objective

Orchestrate development of application and container with docker compose.

## Description

Docker compose can be used to remove a lot of boiler plate commands, and manage both build and execution of multiple services.

To begin with we just wrap our newly created container in a docker compose configuration and test it.

The initial docker compose file `docker-compose.yml` looks like this:

Steps:

* Create a `docker-compose.yml` file
* Add a service `hello-dotnet`
* specify that this service is built from local source with our `Dockerfile` ([see `services` section](https://docs.docker.com/compose/gettingstarted/#step-2-define-services-in-a-compose-file))
* Specify the running containers name
* Specify the name of the image being built
* Test the application with `sudo docker compose up --build`

Solution: [Solution 4](./solutions/dot-net/4.docker-compose/README.md)
Next exercise: [Exercise 5](./exercise-5.md)
Previous exercise: [Exercise 3](./exercise-3.md)
Main readme: [Main readme](./README.md)
