# Exercise 6: Add a front end

## Objective

Create a Node.js frontend that fetches the JSON response from the .NET Web API and displays it.

## Steps

1. Create a simple Express server
2. Fetch data from .NET using axios
3. Display the raw JSON in the browser
4. Add a new service
   1. With network
   2. With dependencies
   3. Expose port 3000
5. Test with e.g. `curl http://localhost:3000`

## Hints

Create a folder for the front end code and configuration:

* `./frontend/Dockerfile` - Containerization of front end
* `./frontend/package.json` - Configuration of Node.js
* `./frontend/index.js` - Node.js application

## Navigation

Solution: [Solution 6](./solutions/6.web-example/README.md)  
Previous exercise: [Exercise 5](./exercise-5.md)  
Main readme: [Main readme](./README.md)
