# Solution 3: Work with Docker Hub and inspect your local Docker environment

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

Link to exercise: [Exercise 3](../../../exercise-3.md)  
Next exercise: [Exercise 4](../../../exercise-4.md)  
Previous exercise: [Exercise 2](../../../exercise-2.md)  
Main readme: [Main readme](../../../README.md)
