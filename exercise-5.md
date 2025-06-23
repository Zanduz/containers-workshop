# Exercise 5: Add a database

## Objective

Convert the .NET app such that it returns the message with data from the database.

## Steps

1. Add a postgresql database container to `docker-compose.yml`.
2. Modify C# code to Query the DB and return JSON data.

Ensure that the containers can communicate on the same network, that the database has persistent storage, that the database gets initialized with some data, and the application prints data from the database.

We can also ask for our application log with `sudo docker compose logs hello-dotnet`.

Make sure to bring down the deployment again with `sudo docker compose down` when done.

## Navigation

Solution: [Solution 5](./solutions/5.multiple-services/README.md)  
Next exercise: [Exercise 6](./exercise-6.md)  
Previous exercise: [Exercise 4](./exercise-4.md)  
Main readme: [Main readme](./README.md)
