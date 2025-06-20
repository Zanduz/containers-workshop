# Exercise 4: Orchestrate development environment

1. Create a new directory for this exercise, e.g. `/~/exercise-4` and move into it. Alternatively, make a copy of the exercise-2 folder.
2. Create the following file-structure:

```txt
exercise-4/
├── app/
│   └── app.py
└── docker-compose.yml
```

3. Give the application's service stack a name by adding the `name: <name>` key-value pair at the top of the `docker-compose.yml` file.
4. Define the application's service stack (`services` [section](https://docs.docker.com/compose/gettingstarted/#step-2-define-services-in-a-compose-file)) of the `docker-compose.yml` file.
5. Build the images and bring up the containers using `sudo docker compose up --build`.

Solution: [Solution 4](./solutions/dot-net/4.docker-compose/README.md)  
Next exercise: [Exercise 5](./exercise-5.md)  
Previous exercise: [Exercise 3](./exercise-3.md)  
Main readme: [Main readme](./README.md)
