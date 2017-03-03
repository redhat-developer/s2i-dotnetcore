fs = require('fs')
// https://www.npmjs.com/package/mustache
var mustache = require ('mustache');
// https://www.npmjs.com/package/html-pdf
var pdf = require('html-pdf');

module.exports = function (callback, templateName, viewData, pdfOptions) {

const DEFAULT_PDF_OPTIONS = {
	format: 'letter',
	orientation: 'landscape', // portrait or landscape
}

	// https://www.npmjs.com/package/mustache
	var mustache = require ('mustache');
	// https://www.npmjs.com/package/html-pdf
	var pdf = require('html-pdf');
	
	// setup mustache template	
	fs = require('fs');
	fs.readFile('Templates/'+templateName+'.mustache', 'utf8', function (err,template) {	
		if (err)
		{
			callback (err, null);
		}
		else
		{	
			// render
			
			var html = mustache.render( template, viewData )		
			
			// PDF options
			var options = Object.assign({}, DEFAULT_PDF_OPTIONS, pdfOptions);
			
			// export as PDF
			pdf.create(html, options).toBuffer(function(err, buffer){
				if (err)
				{
					callback (err, null);
				}
				else
				{					
					callback (null, buffer.toJSON());
				}
			});	    
		}
	});	
};
