/* eslint-env node */

const path = require('path');
const del = require('del');
const gulp = require('gulp');
const $ = require('gulp-load-plugins')();
const depsOk = require('deps-ok');
const webpack = require('webpack');
const _ = require('lodash');

// Needed for mocha tests w/ ES6
require('babel-core/register');

const argv = require('minimist')(process.argv.slice(2));
const PORT = argv.port || 9058;
const HOST = argv.host || 'localhost';

// set variable via $ gulp --production
var IS_PRODUCTION = !!argv.production;
process.env.NODE_ENV = IS_PRODUCTION ? 'production' : 'development';

var BUILD_NUMBER = $.util.env.buildno || 'dev';

// var port = $.util.env.port || 1337;
const IMAGES_DIR_GLOB = 'src/images/**/*.{png,jpg,jpeg,gif}';
const JS_UNIT_TEST_GLOB = 'src/js/**/*_test.js';
const CSS_DIR_GLOB = 'src/sass/**/*.scss';
const HANDLEBARS_DIR_GLOB = 'src/html/**/*.{hbs,html}';
const DIST_DIR = 'dist';
const DEPLOY_PATH = path.join(__dirname, '..', 'Client', 'src', 'SchoolBusClient', 'wwwroot');
const NODE_MODULES_DIR = 'node_modules/';
const JS_SHIMS = [
  // 'node_modules/es5-shim/es5-shim.js',
];
const VENDOR_CSS = [
  'bootstrap/dist/css/bootstrap.css',
  'react-bootstrap-datetimepicker/css/bootstrap-datetimepicker.css',
];

var WEBPACK_CONFIG = require('./webpack.config.js');

function devOnlyPlumber() {
  return !IS_PRODUCTION ? $.plumber() : $.util.noop();
}

gulp.task('deps-ok', done => {
  // NOTE: Only checking NPM modules because deps-ok has poor support for the bower.json github
  // shorthand dependency format.
  const ok = depsOk(process.cwd(), false);
  done(ok ? null : new Error('Found outdated installs'));
});

gulp.task('clean', done => del([DIST_DIR], done));

gulp.task('js:shims', function() {
  if(JS_SHIMS.length === 0) { return Promise.resolve(); }

  const uglifyOptions = {
    compress: {
      global_defs: { TESTING: false },
    },
  };

  return gulp.src(JS_SHIMS)
    .pipe(devOnlyPlumber())
    .pipe($.sourcemaps.init({ loadMaps: true }))
      .pipe(IS_PRODUCTION ? $.uglify(uglifyOptions) : $.util.noop())
      .pipe($.concat('shims.js'))
    .pipe($.sourcemaps.write('./maps'))
    .pipe(gulp.dest(`${DIST_DIR}/js/`));
});

gulp.task('js:modules', () => {
  return gulp.src(_.last(WEBPACK_CONFIG.entry.app))
    .pipe(devOnlyPlumber())
    .pipe($.webpack(WEBPACK_CONFIG, webpack))
    .pipe(gulp.dest(`${DIST_DIR}/js/`))
    .pipe($.size({ title: 'js modules' }));
});

gulp.task('templates', function() {
  var TEMPLATE_DATA = {
    year: new Date().getFullYear(),
    buildNum: BUILD_NUMBER,
    // buildSha: BUILD_GIT_SHA,
    // buildBranch: BUILD_GIT_BRANCH,
    buildTime: new Date(),
  };

  var options = {
    batch : ['./src/html/partials'],
  };

  return gulp.src(['src/html/**/*.hbs', '!src/html/{partials,partials/**}'])
    .pipe(devOnlyPlumber())
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

/** Static Asset Tasks **/

gulp.task('css:vendor', function() {
  var libs = VENDOR_CSS.map(function(path) {
    return NODE_MODULES_DIR + path;
  });

  if(libs.length === 0) { return Promise.resolve(); }

  return gulp.src(libs)
    .pipe(devOnlyPlumber())
    .pipe($.sourcemaps.init({ loadMaps: true }))
      .pipe($.autoprefixer())
      .pipe(IS_PRODUCTION ? $.cleanCss() : $.util.noop())
      .pipe($.concat('vendor.css'))
    .pipe($.sourcemaps.write('./maps'))
    .pipe(gulp.dest(DIST_DIR + '/css/'));
});

gulp.task('robots.txt', () => {
  return gulp.src(['src/robots.txt'])
    .pipe($.size({ title: 'robots.txt' }))
    .pipe(gulp.dest(`${DIST_DIR}/`));
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

gulp.task('webConfig', function() {
  return gulp.src('src/web.config')
    .pipe($.size({ title : 'webConfig' }))
    .pipe(gulp.dest(DIST_DIR));
});


/* Production Build Tasks */

gulp.task('fingerprint', () => {
  var options = {
    // debug: true,
    dontSearchFile: [ /\.map$/ ], // Don't bother fingerprinting sourcemaps
    dontRenameFile: [
      /\/(index|login)\.html$/, // Don't fingerprint since they are un-fingerprinted URLs for the client.
    ],
  };

  return gulp.src([`${DIST_DIR}/**`])
    .pipe(devOnlyPlumber())
    .pipe($.revAll.revision(options))
    .pipe(gulp.dest('dist'))
    .pipe($.revAll.versionFile())
    .pipe(gulp.dest('dist'));
});


/* Testing Tasks */

gulp.task('test:integration', function() {
  return gulp
    .src('test/index.html')
    .pipe($.mochaPhantomjs());
});

gulp.task('test:unit', function() {
  return gulp.src(JS_UNIT_TEST_GLOB, { read: false })
    .pipe($.mocha());
});


/* Watch Task */

gulp.task('watch', function() {
  gulp.watch(IMAGES_DIR_GLOB, gulp.series('images'));
  gulp.watch(CSS_DIR_GLOB, gulp.series('sass'));
  gulp.watch([JS_UNIT_TEST_GLOB, 'test/js/**/*.js'], gulp.series('test:unit'));
  gulp.watch(HANDLEBARS_DIR_GLOB, gulp.series('templates'));
});


/* Dev Server Task */

var server = $.liveServer(['server/main.js', `--port=${PORT}`, `--host=${HOST}`], {}, false);

gulp.task('server:dev', function(done) {
  server.start();

  gulp.watch(['server/main.js', 'webpack.config.js']).on('change', function() {
    server.start.bind(server)();
    console.log('Reloading dev server');
  });

  done();
});


/* Build Tasks */

gulp.task('assets:static', gulp.parallel('robots.txt', 'images', 'fonts', 'css:vendor', 'js:shims'));
gulp.task('styles', gulp.parallel('sass', 'css:vendor'));

gulp.task('build:assets:simple', gulp.parallel('styles', 'assets:static', 'templates'));
gulp.task('build:assets', gulp.parallel('build:assets:simple', 'js:modules'));

gulp.task('build:complete', gulp.series(
  'deps-ok',
  'clean',
  'test:unit',
  'build:assets',
  // 'test:integration',
  'fingerprint'
));

gulp.task('build:dev', gulp.series(
  'deps-ok',
  'clean',
  'test:unit',
  'build:assets:simple',
  gulp.parallel('watch', 'server:dev')
));

gulp.task('build', gulp.series('clean', 'build:assets'));

gulp.task('default', gulp.series(IS_PRODUCTION ? 'build:complete' : 'build:dev'));

gulp.task('test', gulp.series('test:unit', 'build', 'test:integration'));


/* Deploy Tasks */

gulp.task('deploy:setprod', function() {
  process.env.NODE_ENV = 'production';
  IS_PRODUCTION = true;
  return Promise.resolve();
});

gulp.task('deploy:clean', function(done) {
  del([DEPLOY_PATH], done);
});

gulp.task('deploy:copy', function() {
  return gulp.src(DIST_DIR).pipe(gulp.dest(DEPLOY_PATH));
});

gulp.task('deploy', gulp.series('deploy:setprod', 'build:complete', 'deploy:clean', 'deploy:copy'/*, 'deploy:commit'*/));
