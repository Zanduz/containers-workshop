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

[Exercise 0: Flight-check](./exercise-0.md)  
[Exercise 1: Create an application or bring your own](./exercise-1.md)  
[Exercise 2: Containerize your application](./exercise-2.md)  
[Exercise 3: Work with Docker Hub and inspect your local Docker environment](./exercise-3.md)  
[Exercise 4: Orchestrate development environment](./exercise-4.md)  
[Exercise 5: Add a database](./exercise-5.md)  
[Exercise 6: Add a front end](./exercise-6.md)  
