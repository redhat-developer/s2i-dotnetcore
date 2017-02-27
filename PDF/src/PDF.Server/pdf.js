fs = require('fs')
// https://www.npmjs.com/package/mustache
var mustache = require ('mustache');
// https://www.npmjs.com/package/html-pdf
var pdf = require('html-pdf');

const DEFAULT_PDF_OPTIONS = {
	format: 'Letter',
	orientation: 'landscape', // portrait or landscape
}

function buildPDF(templateName, viewData, pdfOptions) {
	return new Promise(function(resolve, reject) {
		// read mustache template
		fs.readFile(`Templates/${templateName}.mustache`, 'utf8', function(err, template) {
			if (err) { return reject(err); }

			// Process mustache template
			var html = mustache.render(template, viewData);

			// PDF options
			var options = Object.assign({}, DEFAULT_PDF_OPTIONS, pdfOptions);

			// export as PDF
			pdf.create(html, options).toBuffer(function(err, buffer) {
				if (err) { return reject(err); }

				resolve(buffer)
			});
		});
	});
};


module.exports = buildPDF;
