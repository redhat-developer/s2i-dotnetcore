// basic test for the pdf engine.

var pdf = require('./pdf.js');

console.log ("Testing PDF Export");

var DATA = {
	permitNumber: '32-46938',
	permitIssueDate: '27-Mar-2016',
	schoolBusOwnerName: 'Wilson Transportation Ltd.',
	schoolBusOwnerAddressLine1: '4196 GLANFORD AVE',
	schoolBusOwnerAddressLine2: 'VICTORIA, BC, V8Z 4B6',
	icbcRegistrationNumber: '38472962',
	vehicleIdentificationNumber: '1GOWD46K732283902',
	icbcModelYear: '2010',
	icbcMake: 'CHEVROLET',
	restrictionsText: 'No restrictions',
	schoolDistrictshortName: 'SD 62',
	schoolBusSeatingCapacity: '015',
}

var templateName = 'schoolbus_permit';

pdf(templateName, DATA).then(function(pdfDataBuffer) {
	// save the buffer to a file.
	fs.open(`${templateName}.pdf`, 'w', function(err, fd) {
		if (err) {
			console.log ('error opening file: ' + err);
		} else {
			fs.write(fd, pdfDataBuffer, 0, pdfDataBuffer.length, null, function(err) {
				if (err) {
					console.log ('error writing file: ' + err);
				} else {
					fs.close(fd, function() {
						console.log(`${templateName}.pdf contains the output of this script.`);
					})
				}
			});
		}
	});
}).catch(function(err) {
	console.log ("Error rendering pdf.");
	console.log (err);
});
