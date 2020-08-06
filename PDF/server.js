var express = require("express"),
  app = express(),
  pdf = require("./pdf"),
  moment = require("moment");

var port = process.env.PORT || process.env.OPENSHIFT_NODEJS_PORT || 8080,
  ip = process.env.IP || process.env.OPENSHIFT_NODEJS_IP || "0.0.0.0";

app.use(express.json());

app.use(function (err, req, res, next) {
  console.error(err.stack);
  res.sendStatus(500);
});

app.get("/", function (req, res) {
  res.sendStatus(200);
});

app.post("/api/PDF/GetPDF", function (req, res) {
  var data = req.body;
  var options = {
    format: "Letter",
    orientation: "landscape",
    phantomArgs: ["--local-url-access=false"],
  };

  pdf(
    function (err, stream) {
      if (err) {
        console.error(
          "[" + moment().format("YYYY-MM-DD HH:mm:ss") + "] " + err.stack
        );
        res.status(500).send("Server Error!");
      }

      console.log(
        "[" +
          moment().format("YYYY-MM-DD HH:mm:ss") +
          "] Permit PDF: " +
          data.permitNumber
      );

      var filename = "Permit-" + data.permitNumber + ".pdf";
      filename = encodeURIComponent(filename);
      res.setHeader(
        "Content-disposition",
        'attachment; filename="' + filename + '"'
      );
      res.setHeader("Content-type", "application/pdf");
      stream.pipe(res);
    },
    "schoolbus_permit",
    data,
    options
  );
});

app.listen(port, ip);
console.log("Server running on http://%s:%s", ip, port);

module.exports = app;
