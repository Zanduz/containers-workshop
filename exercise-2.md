# Exercise 2: Containerize your application

## Objective

The purpose of this exercise is to try to build your own image and run it and thereby get familiar with the duality of images and containers.

Steps:

1. Create a new directory somewhere in the WSL filesystem e.g. `/~/exercise-2` and move into it.
2. Write a small hello-world application in a language of your choice (as long as there is a runtime Docker image for it, e.g. [Python](https://hub.docker.com/_/python) or [.NET](mcr.microsoft.com/dotnet/runtime:8.0.17)).
3. Create a Dockerfile and base it on a runtime Docker image.
4. Copy the application into the image.
5. Make sure your Dockerfile executes the application.
6. Build the image with a fitting tag of your choice.
7. Check your local image registry to see that the image has been added there.
8. Run a container from the image.
9. List all containers, including stopped/exited ones.

Solution: [Solution 2](./solutions/solution-2.md)
Next exercise: [Exercise 3](./exercise-3.md)
Previous exercise: [Exercise 1](./exercise-1.md)
Main readme: [Main readme](./README.md)
