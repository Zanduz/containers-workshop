# Containers Workshop

A practical introduction to Containers.

Solutions are given at the bottom, but you are encouraged to try to do the exercises without them. Use the [Docker documentation](https://docs.docker.com/) or search the web.

## Setup

It is assumed that Windows is the platform used.

<b> Step 1: Install Linux (via WSL) </b>

Start by installing WSL (Windows Subsystem for Linux).  
Open PowerShell as Administrator and run the following command. Expect a reboot after installation:

```ps
wsl --install
```

More information can be found [here](https://learn.microsoft.com/en-us/windows/wsl/install). 

After installation, restart your computer. Once restarted, open PowerShell again and install Ubuntu with the following command:

```ps
wsl --install --ubuntu
```

The installation may take a few minutes.  
You will be prompted to create a username and password — make sure to remember them, as they’ll be required for certain commands.

After installation, you’ll be in a Linux terminal.
Going forward, you can also launch the Linux terminal (Bash) from any folder by running :

```ps
bash
```

in either PowerShell or CMD.

<b> Step 2: Install Docker </b>

By default, Ubuntu does not come with Docker pre-installed.

Follow [this guide](https://docs.docker.com/engine/install/ubuntu/) to install Docker on Ubuntu.

<b> Step 3: Verify the Docker Installation </b>

You can verify that Docker is working by running:

```bash
sudo docker run hello-world
```

in the Linux terminal (Bash).

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
2. Write a small hello-world application in a language of your choice (as long as there is a runtime Docker image for it, e.g. [Python](https://hub.docker.com/_/python)).
3. Create a Dockerfile and base it on the runtime Docker image.
4. Copy the application into the image.
5. Make sure your Dockerfile executes the application.
6. Build the image and run it.

```bash
$ docker build -t my-python-app .
$ docker run -it --rm --name my-running-app my-python-app
```

### Exercise 3: Registries

1. Pull an image you have not yet worked with from the [Docker hub](https://hub.docker.com), e.g. [PostgresSQL](https://hub.docker.com/r/bitnami/postgresql).
2. List all images in your local registry.
3. Pull a version of that image that is *not* the latest.
4. List all images in your local registry again. What do you see?
5. Remove the older version from your local registry again.
6. Tag the image you built in the previous exercise with a tag of your choice.
7. Push your image to ... #TODO

### Exercise 4: Docker Compose

1. Create a new directory for this exercise, e.g. `/~/exercise-4` and move into it. Alternatively, make a copy of the exercise-2 folder.
2. Create the following file-structure:

```txt
exercise-4/
├── app/
│   └── app.py
└── docker-compose.yml
```

3. Define the `version`, `services`, `volumes` and `networks` sections of the `docker-compose.yml` file.
4. Bring up the containers using `docker compose up --build`.