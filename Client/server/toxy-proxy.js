#!/usr/bin/env node

/*eslint-env node*/

'use strict';

var toxy = require('../node_modules/toxy');
var argv = require('minimist')(process.argv.slice(2));

var port = argv.port || argv.p || 8000;
var proxy = toxy();
// var rules = proxy.rules;
var poisons = proxy.poisons;

proxy.forward('http://localhost:' + port);

proxy.all('/api/*')
  .poison(poisons.latency({ min: 500, max: 2000 }))
  .poison(poisons.slowRead({ bps: 100 }));

proxy.all('/*');

proxy.listen(3000);
console.log('Server listening on port:', 3000);
console.log('Proxying to API on port:', port);
