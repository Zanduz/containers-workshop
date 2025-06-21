# Exercise 2: Containerize your application

## Objective

The purpose of this exercise is to try to build your own image and run it and thereby get familiar with the duality of images and containers.

## Steps

1. Continue with the application from the previous exercise.
2. Write a Dockerfile that:
   1. Has two separate stages: One for building the binary, and another where the binary gets copied to the second stage.
   2. Uses a .NET SDK image in the first stage. Name this image 'build'.
   3. Copies csproj in and restores the dependencies.
   4. Copies the application source code into the image.
   5. Builds the app.
   6. Publishes the compiled app.
   7. Uses a .NET Runtime image in the second stage to run the published output, copied from the 'build' stage.
3. Use Docker to build an image from your Dockerfile. Assign a name (and optionally a version tag) to the image.
4. Check your local image registry to see that the image has been added there.
5. Run a container from the image.
6. List all containers, including stopped/exited ones.

## Navigation

Solution: [Solution 2](./solutions/2.container/README.md)  
Next exercise: [Exercise 3](./exercise-3.md)  
Previous exercise: [Exercise 1](./exercise-1.md)  
Main readme: [Main readme](./README.md)
