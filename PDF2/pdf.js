module.exports = function (callback, templateName, viewData, pdfOptions) {

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
			var html = mustache.render( template, viewData );

			// export as PDF
			pdf.create(html, pdfOptions).toStream(function(err, stream){
				if (err)
				{
					callback (err, null);
				}
				else
				{
					callback (null, stream);
				}
			});
		}
	});
};