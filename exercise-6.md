# Exercise 6: Add a front end

## Objective

Create a Node.js frontend that fetches the JSON response from the .NET Web API and displays it.

Steps:

* Create a simple Express server
* Fetch data from .NET using axios
* Display the raw JSON in the browser
* Add a new service
  * With network
  * With dependencies
  * Expose port 3000

## Hints

* Create a folder for the front end code and configuration
  * `./frontend/Dockerfile` - Containerization of front end
  * `./frontend/package.json` - Configuration of Node.js
  * `./frontend/index.js` - Node.js application
