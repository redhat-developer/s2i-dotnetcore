// basic test for the pdf engine.

var pdf = require('./pdf.js');

console.log ("Testing PDF Export");

pdf(function (error, bufferJSON){
	if (error)
	{
		console.log ("Error rendering pdf.");
		console.log (error);
	}
	else
	{		
		var buffer = Buffer.from(bufferJSON.data);
		// save the buffer to a file.
		fs.open('sample.pdf', 'w', function(err, fd) {
			if (err) {
				console.log ('error opening file: ' + err);
			}
			else
			{
				
			fs.write(fd, buffer, 0, buffer.length, null, function(err) {
				if (err) {
					console.log ('error writing file: ' + err);
				}
				else
				{
					fs.close(fd, function() {
						console.log('sample.pdf contains the output of this script.');
					})
				}
			});
			}
		});
	}
});
