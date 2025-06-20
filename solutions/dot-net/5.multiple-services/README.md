# Solution 5: Add a database

Docker compose makes it easy to manage multiple dependencies of the application you develop.

By adding a virtual docker network to our compose setup, we allow the services to communicate.

```yaml
networks:
  local_network:
    driver: bridge

services:
  hello-dotnet:
    ...
    networks:
      - local_network

  database:
    ...
    networks:
      - local_network
```

We then add our postgresql database service and update our application with connection information.

```yaml
services:
  hello-dotnet:
    ...
    depends_on:
      - database
    environment:
      ConnectionStrings__DefaultConnection: Host=database;Port=5432;Username=helloworld;Password=helloworld;Database=hellodb

  database:
    # https://hub.docker.com/_/postgres
    image: postgres:17.5-alpine
    environment:
      POSTGRES_USER: helloworld
      POSTGRES_PASSWORD: helloworld
      POSTGRES_DB: hellodb
    volumes:
      - postgres_data:/var/lib/postgresql/data
    ports:
      - "5432:5432"
    networks:
      - local_network
```

Since the database needs to persist data, we also provide it with a docker volume:

```yaml
services:
  hello-dotnet:
    ...

  database:
    ...
    volumes:
      - postgres_data:/var/lib/postgresql/data

volumes:
  postgres_data:
```

When we have updated our application code to utilize the database, we can re-compile `sudo docker compose build` and run `sudo docker compose up --detach`. This time we choose to `--detach` the servies from the console output, otherwise our console would be tied to the running services (postgresql does not stop unless asked to).

We can now ask for our application log with `sudo docker compose logs hello-dotnet`.

We can also see the running services with `sudo docker compose ps --all`. Notice that our application stopped running, while postgresql continues to run.

Link to exercise: [Exercise 5](../../../exercise-5.md)  
Next exercise: [Exercise 6](../../../exercise-6.md)  
Previous exercise: [Exercise 4](../../../exercise-4.md)  
Main readme: [Main readme](../README.md)
