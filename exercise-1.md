# Exercise 1: Flight-check and prepare your own application or bring your own

If you followed the setup steps and verified that you have a working instance of Docker on you machine, then you can skip this exercise. If you already may have a working instance of Docker on your machine and did not follow the setup steps above, then do this exercise.

The purpose of this execise is to try the `run` sub-command and to do a flight-check.

1. Run the following command in the Linux terminal:

```bash
sudo docker run hello-world
```

This command pulls the `hello-world` image from the Internet and instantiates a container from it.

The console output is expected to look like:

```log
Unable to find image 'hello-world:latest' locally
latest: Pulling from library/hello-world
e6590344b1a5: Pull complete
Digest: sha256:c41088499908a59aae84b0a49c70e86f4731e588a737f1637e73c8c09d995654
Status: Downloaded newer image for hello-world:latest

Hello from Docker!...
```

If you see this message, then Docker is working correctly.

# Solution

