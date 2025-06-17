const express = require("express");
const axios = require("axios");
const app = express();

app.get("/", async (req, res) => {
  try {
    const response = await axios.get("http://hello-dotnet:8080");
    res.send(`Frontend says: "${response.data}"`);
  } catch (err) {
    res.status(500).send("Error calling backend");
  }
});

app.listen(3000, () => {
  console.log("Frontend listening on port 3000");
});
