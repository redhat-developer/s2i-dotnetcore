'use strict';
const task = require('./lib/build.js')
const settings = require('./lib/config.js')

task(Object.assign(settings, { phase: 'build'}))
