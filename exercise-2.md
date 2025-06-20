# Exercise 2: Containerize your application

## Objective

The purpose of this exercise is to try to build your own image and run it and thereby get familiar with the duality of images and containers.

## Steps

1. Continue with the application from the previous exercise.
2. Create a Dockerfile and base it on a fitting SDK Docker image. Name this image 'build'.
3. Copy csproj in and restore project.
4. Copy the application source code into the image.
5. In the same Dockerfile, create a new image and base it on a fitting runtime Docker image.
6. Copy the built application binary from the 'build' image.
7. Make sure your Dockerfile executes the application.
8. Build the image with a fitting tag of your choice.
9. Check your local image registry to see that the image has been added there.
10. Run a container from the image.
11. List all containers, including stopped/exited ones.

Solution: [Solution 2](./solutions/dot-net/2.container/README.md)  
Next exercise: [Exercise 3](./exercise-3.md)  
Previous exercise: [Exercise 1](./exercise-1.md)  
Main readme: [Main readme](./README.md)
