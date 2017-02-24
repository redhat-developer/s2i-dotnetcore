module.exports = function (callback) {

	// https://www.npmjs.com/package/mustache
	var mustache = require ('mustache');
	// https://www.npmjs.com/package/html-pdf
	var pdf = require('html-pdf');
	
	// setup mustache template	
	fs = require('fs');
	fs.readFile('Templates/sample.mst', 'utf8', function (err,template) {	
		if (err)
		{
			callback (err, null);
		}
		else
		{	
			// fake view for example purposes.
			var view = {
				title: "Hello World"
			};
			
			// render
			
			var html = mustache.render( template, view )		
			
			// PDF options
			var options = { format: 'Letter' };
			
			// export as PDF
			pdf.create(html).toBuffer(function(err, buffer){
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