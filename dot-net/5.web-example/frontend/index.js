const express = require("express");
const axios = require("axios");
const app = express();

app.get("/", async (req, res) => {
  try {
    const response = await axios.get("http://hello-dotnet:8080");
    res.setHeader("Content-Type", "application/text");
    res.send(`Frontend says: "${JSON.stringify(response.data, null, 2)}"`);
  } catch (err) {
    console.error("Error contacting backend:", err.message);
    res.status(500).send("Error calling backend");
  }
});

app.listen(3000, () => {
  console.log("Frontend listening on port 3000");
});
