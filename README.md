# Containers Workshop

A practical introduction to Containers.

Solutions are given at the bottom, but you are encouraged to try to do the exercises without them. Use the [Docker documentation](https://docs.docker.com/) or search the web.

## Setup

It is assumed that Windows is used and that neither WSL nor Docker is installed on the system.

<b> Step 1: Install Linux (via WSL) </b>

Start by installing WSL (Windows Subsystem for Linux). More information can be found [here](https://learn.microsoft.com/en-us/windows/wsl/install).

Open PowerShell as Administrator and run the following command:

```ps
> wsl --install
```

Reboot your machine. Once rebooted, the installation will proceed and may take some time. You will be prompted to create a username and password — make sure to remember them, as they’ll be required for certain commands.

Following a successful installation, you should see a Linux terminal.

If a Linux distribution is not installed in WSL, then run:

```ps
> wsl --install -d ubuntu
```

You may need to reboot once more.

Going forward, you can also launch the Linux terminal (bash) from any folder by running:

```ps
> bash
```

in either PowerShell or CMD.

<b> Step 2: Install Docker </b>

By default, Ubuntu does not come with Docker pre-installed. Follow the below steps from [the official guide](https://docs.docker.com/engine/install/ubuntu/) to install Docker on Ubuntu.

```bash
# Add Docker's official GPG key:
$ sudo apt update
$ sudo apt install ca-certificates curl
$ sudo install -m 0755 -d /etc/apt/keyrings
$ sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
$ sudo chmod a+r /etc/apt/keyrings/docker.asc

# Add the repository to Apt sources:
$ echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu \
  $(. /etc/os-release && echo "${UBUNTU_CODENAME:-$VERSION_CODENAME}") stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
$ sudo apt update


$ sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin
```

<b> Step 3: Verify the Docker Installation </b>

You can verify that Docker is working by running:

```bash
$ sudo docker run hello-world
```

in the Linux terminal (bash).

This command pulls the `hello-world` image from the Internet (Docker Hub) and instantiates a container from it.

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

## Exercises

### Exercise 1: Flight-check

If you followed the setup steps above and verified that you have a working instance of Docker on you machine, then you can skip this exercise. If you already may have a working instance of Docker on your machine and did not follow the setup steps above, then do this exercise.

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

### Exercise 2: Build and run

The purpose of this exercise is to try to build your own image and run it and thereby get familiar with the duality of images and containers.

1. Create a new directory somewhere in the WSL filesystem e.g. `/~/exercise-2` and move into it.
2. Write a small hello-world application in a language of your choice (as long as there is a runtime Docker image for it, e.g. [Python](https://hub.docker.com/_/python) or [.NET](mcr.microsoft.com/dotnet/runtime:8.0.17)).
3. Create a Dockerfile and base it on the runtime Docker image.
4. Copy the application into the image.
5. Make sure your Dockerfile executes the application.
6. Build the image with a fitting tag of your choice.
7. Check your local image registry to see that the image has been added there.
8. Run a container from the image.
9. List all containers, including stopped/exited ones.

### Exercise 3: Local registry and tags

1. Pull an image you have not yet worked with from the [Docker hub](https://hub.docker.com), e.g. [PostgresSQL](https://hub.docker.com/r/bitnami/postgresql).
2. List all images in your local registry.
3. Pull a version of that image that is *not* the latest.
4. List all images in your local registry again. What do you see?
5. Remove the older version from your local registry again.
6. Tag the image you built in the previous exercise with a tag of your choice.
7. List all images in your local registry again. What do you see now?

### Exercise 4: Docker Compose

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
5. Build the images and bring up the containers using `docker compose up --build`.

## Solutions

### Solution 2

#### .NET solution

```bash
$ mkdir -p ~/exercise-2
$ cd ~/exercise-2

# Create a .NET hello-world app
$ cat <<EOF > Helloworld.cs
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello from Docker (.NET)!");
    }
}
EOF

# Create the Dockerfile
$ cat <<EOF > Dockerfile
# Build stage using dotnet sdk image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage using slimmer runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "exercise-2-dotnet.dll"]
EOF

# Build the image
$ sudo docker build -t hello-dotnet .

# Run the container
$ sudo docker run hello-dotnet

# List all containers, including stopped/exited ones.
$ sudo docker ps -a
```

#### Python solution

```bash
# Create the exercise directory
$ mkdir -p ~/exercise-2
$ cd ~/exercise-2

# Create a Python hello-world app
$ cat <<EOF > app.py
print("Hello from Docker!")
EOF

# Create the Dockerfile
$ cat <<EOF > Dockerfile
FROM python:3-slim
WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
EOF

# Build the image
$ sudo docker build -t hello-python .

# Check the local registry
$ sudo docker images

# Run the container
$ sudo docker run hello-python

# List all containers, including stopped/exited ones.
$ sudo docker ps -a
```

### Solution 3

```bash
$ sudo docker pull bitnami/postgresql
$ sudo docker images [list] [-a]
$ sudo docker pull bitnami/postgresql:17.5.0-debian-12-r10
$ sudo docker images [list] [-a]
$ sudo docker rmi bitnami/postgresql:17.5.0-debian-12-r10
$ sudo docker images [list] [-a]
$ sudo docker tag bitnami/postgresql bitnami/postgresql:mytag
$ sudo docker images [list] [-a]
```

### Solution 4

Tilføj her.