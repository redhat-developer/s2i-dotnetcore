/*eslint-env node*/

'use strict';

global.Promise = require('es6-promise').Promise;

// https://github.com/wbkd/react-starterkit

// https://github.com/webpack/react-starter


// PRODUCTION TODOs:
//   - static asset finger-printing (use gulp-rev + gulp-fingerprint)


var run = require('run-sequence');
var del = require('del');
var gulp = require('gulp');
var gutil = require('gulp-util');
var depsOk = require('deps-ok');
var git = require('git-rev-sync');
var $ = require('gulp-load-plugins')();

// Needed for mocha tests w/ ES6
require('babel-core/register');

var argv = require('minimist')(process.argv.slice(2));

var PORT = argv.port || 9002;
// set variable via $ gulp --production
var IS_PRODUCTION = !!argv.production;
process.env.NODE_ENV = IS_PRODUCTION ? 'production' : 'development';

var BUILD_NUMBER = $.util.env.buildno || 'dev';

// var port = $.util.env.port || 1337;
var IMAGES_DIR_GLOB = 'src/images/**/*.{png,jpg,jpeg,gif}';
var JS_UNIT_TEST_GLOB = 'src/js/**/*_test.js';
var CSS_DIR_GLOB = 'src/sass/**/*.scss';
var HANDLEBARS_DIR_GLOB = 'src/html/**/*.{hbs,html}';
var DIST_DIR = 'dist';
var NODE_MODULES_DIR = 'node_modules/';
var SHIMS = [
  'es5-shim/es5-shim.js',
];
var VENDOR_CSS = [
  'bootstrap/dist/css/bootstrap.css',
  'react-bootstrap-datetimepicker/css/bootstrap-datetimepicker.css',
];

var WEBPACK_CONFIG = require('./webpack.config.js');

var BUILD_GIT_SHA = 'dev', BUILD_GIT_BRANCH = 'dev';
try {
  BUILD_GIT_SHA = git.long() || 'dev';
  BUILD_GIT_BRANCH = git.branch() || 'dev';
} catch(e) { /* ignore git errors - assume dev */ }

gulp.task('deps-ok', function() {
  var ok = depsOk(process.cwd(), false /* verbose */);
  if(!ok) {
    gulp.emit('error', new gutil.PluginError('deps-ok', 'Found outdated installs'));
  }
});


gulp.task('clean', function(cb) {
  return del([DIST_DIR], cb);
});


gulp.task('js:shims', function() {
  var libs = SHIMS.map(function(path) {
    return NODE_MODULES_DIR + path;
  });

  return gulp.src(libs)
    .pipe($.sourcemaps.init())
    .pipe($.concat('js/shims.js'))
    .pipe($.sourcemaps.write('./js/maps'))
    .pipe(gulp.dest(DIST_DIR));
});

gulp.task('js', function() {
  return gulp.src(WEBPACK_CONFIG.entry)
    .pipe($.webpack(WEBPACK_CONFIG))
    .pipe(gulp.dest(DIST_DIR + '/js/'))
    .pipe($.size({ title : 'js' }));
});


gulp.task('html', function() {
  var TEMPLATE_DATA = {
    year: new Date().getFullYear(),
    buildNum: BUILD_NUMBER,
    buildSha: BUILD_GIT_SHA,
    buildBranch: BUILD_GIT_BRANCH,
    buildTime: new Date(),
  };

  var options = {
    batch : ['./src/html/partials'],
  };

  return gulp.src(['src/html/**/*.hbs', '!src/html/{partials,partials/**}'])
    .pipe($.compileHandlebars(TEMPLATE_DATA, options))
    .pipe($.rename({ extname: '.html' }))
    .pipe(gulp.dest(DIST_DIR));
});


gulp.task('sass', function() {
  return gulp.src('src/sass/main.scss')
    .pipe($.sourcemaps.init())
      .pipe($.sass().on('error', $.sass.logError))
      .pipe($.autoprefixer())
      .pipe(IS_PRODUCTION ? $.cleanCss() : $.util.noop())
    .pipe($.sourcemaps.write('./maps'))
    .pipe($.size({ title : 'css' }))
    .pipe(gulp.dest(DIST_DIR + '/css/'));
});

gulp.task('css', function() {
  var libs = VENDOR_CSS.map(function(path) {
    return NODE_MODULES_DIR + path;
  });

  return gulp.src(libs)
    .pipe($.sourcemaps.init({ loadMaps: true }))
      .pipe($.autoprefixer())
      .pipe(IS_PRODUCTION ? $.cleanCss() : $.util.noop())
      .pipe($.concat('vendor.css'))
    .pipe($.sourcemaps.write('./maps'))
    .pipe(gulp.dest(DIST_DIR + '/css/'));
});

gulp.task('images', function() {
  return gulp.src(IMAGES_DIR_GLOB)
    .pipe($.size({ title : 'images' }))
    .pipe(gulp.dest(DIST_DIR + '/images/'));
});

gulp.task('fonts', function() {
  return gulp.src(['node_modules/bootstrap/dist/fonts/**'])
    .pipe($.size({ title : 'fonts' }))
    .pipe(gulp.dest(DIST_DIR + '/fonts/'));
});

gulp.task('mockAPI', function() {
  return gulp.src('src/mockAPI/**/*.json')
    .pipe($.size({ title: 'mockAPI' }))
    .pipe(gulp.dest(DIST_DIR + '/mockAPI/'));
});

gulp.task('webConfig', function() {
  return gulp.src('src/web.config')
    .pipe($.size({ title : 'webConfig' }))
    .pipe(gulp.dest(DIST_DIR));
});


gulp.task('watch', function() {
  gulp.watch(IMAGES_DIR_GLOB, ['images']);
  gulp.watch(CSS_DIR_GLOB, ['sass']);
  gulp.watch([JS_UNIT_TEST_GLOB, 'test/js/**/*.js'], ['test:js']);
  gulp.watch(HANDLEBARS_DIR_GLOB, ['html']);
  gulp.watch('src/mockAPI/**/*.json', ['mockAPI']);
});


var server = $.liveServer(['server/main.js', '--port=' + PORT], {}, false);

gulp.task('server:dev', function(done) {
  server.start();

  gulp.watch(['server/main.js', 'webpack.config.js']).on('change', function() {
    server.start.bind(server)();
    console.log('Reloading dev server');
  });

  done();
});

gulp.task('mocha-phantomjs', function() {
  return gulp
    .src('test/index.html')
    .pipe($.mochaPhantomjs());
});

gulp.task('test:js', function() {
  return gulp.src(JS_UNIT_TEST_GLOB, { read: false })
    .pipe($.mocha());
});


gulp.task('build:dev', ['deps-ok', 'images', 'webConfig', 'html', 'js:shims', 'css', 'sass', 'mockAPI', 'fonts', 'watch', 'server:dev', 'test:js']);

gulp.task('build:production:app', ['clean'], function(cb) {
  run(['deps-ok', 'images', 'webConfig', 'html', 'js', 'js:shims', 'css', 'sass', 'mockAPI', 'fonts'], cb);
});

gulp.task('test:integration', ['build:production:app'], function() {
  return gulp.start(['mocha-phantomjs']);
});

gulp.task('test', ['test:js', 'test:integration']);

gulp.task('build:production', ['test']);

if(IS_PRODUCTION) {
  console.log('Production Build');
}

gulp.task('default', [IS_PRODUCTION ? 'build:production': 'build:dev']);
