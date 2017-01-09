/*eslint-env node*/

const path = require('path');
const webpack = require('webpack');
const _ = require('lodash');

const IS_PRODUCTION = process.env.NODE_ENV === 'production';


var webpackPlugins = [
  new webpack.optimize.CommonsChunkPlugin('vendor', 'vendor.js'),
];

if(IS_PRODUCTION) {
  webpackPlugins.push(new webpack.optimize.UglifyJsPlugin({
    compress: {
      warnings: false,
    },
    mangle: {
      except: [ '$super', '$', 'exports', 'require' ],
    },
  }));
  // TODO: See if this is necessary
  webpackPlugins.push(new webpack.DefinePlugin({
    'process.env':{
      'NODE_ENV': JSON.stringify('production'),
    },
  }));
} else {
  webpackPlugins.push(new webpack.optimize.OccurenceOrderPlugin());
  webpackPlugins.push(new webpack.HotModuleReplacementPlugin());
}

module.exports = {
  devtool: IS_PRODUCTION ? 'source-map' : 'eval',
  entry: {
    app: _.compact([
      IS_PRODUCTION ? null : 'webpack-hot-middleware/client',
      './src/js/init.js',
    ]),
    vendor: [
      'jquery',
      'bluebird',
      'lodash',
      'react',
      'react-bootstrap',
      'react-bootstrap-datetimepicker',
      'react-dom',
      'react-redux',
      'react-router',
      'react-router-bootstrap',
      'redux',
    ],
  },
  output: {
    path: path.join(__dirname, '/dist/'),
    filename: 'app.js',
    publicPath: '/',
  },
  plugins: webpackPlugins,
  module: {
    preLoaders: [
      {
        test: /\.jsx?$/,
        loader: 'eslint-loader',
        exclude: /node_modules/,
      },
    ],
    loaders: [{
      test: /\.jsx?$/,
      exclude: /node_modules/,
      loaders: ['react-hot', 'babel'],
    }],
  },
  eslint: {
    failOnWarning: IS_PRODUCTION,
    failOnError: true,
  },
};
