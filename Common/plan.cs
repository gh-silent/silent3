Skip to content
This repository
Search
Pull requests
Issues
Marketplace
Gist
 @gh-silent
 Sign out
 Watch 1
  Star 0
  Fork 0 bketelsen/rocksweb
 Code  Issues 0  Pull requests 0  Projects 0  Wiki Insights 
Branch: master Find file Copy pathrocksweb/webpack.config.js
4ad71ae  an hour ago
@markbates markbates Initial Commit
1 contributor
RawBlameHistory     
86 lines (84 sloc)  2.02 KB
var webpack = require("webpack");
var CopyWebpackPlugin = require('copy-webpack-plugin');
var ExtractTextPlugin = require("extract-text-webpack-plugin");

module.exports = {
  entry: [
    "./assets/js/application.js",
    "./assets/css/application.scss",
    "./node_modules/jquery-ujs/src/rails.js"
  ],
  output: {
    filename: "application.js",
    path: __dirname + "/public/assets"
  },
  plugins: [
    new webpack.ProvidePlugin({
      $: "jquery",
      jQuery: "jquery"
    }),
    new ExtractTextPlugin("application.css"),
    new CopyWebpackPlugin([{
      from: "./assets",
      to: ""
    }], {
      ignore: [
        "css/*",
        "js/*",
      ]
    }),
    new webpack.LoaderOptionsPlugin({
      minimize: true,
      debug: false
    }),
    new webpack.optimize.UglifyJsPlugin({
      beautify: false,
      mangle: {
        screw_ie8: true,
        keep_fnames: true
      },
      compress: {
        screw_ie8: true
      },
      comments: false
    })
  ],
  module: {
    rules: [{
      test: /\.jsx?$/,
      loader: "babel-loader",
      exclude: /node_modules/
    }, {
      test: /\.scss$/,
      use: ExtractTextPlugin.extract({
        fallback: "style-loader",
        use:
        [{
          loader: "css-loader",
          options: { sourceMap: true }
      	},
        {
          loader: "sass-loader",
          options: { sourceMap: true }
        }]
      })
    }, {
      test: /\.woff(\?v=\d+\.\d+\.\d+)?$/,
      use: "url-loader?limit=10000&mimetype=application/font-woff"
    }, {
      test: /\.woff2(\?v=\d+\.\d+\.\d+)?$/,
      use: "url-loader?limit=10000&mimetype=application/font-woff"
    }, {
      test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
      use: "url-loader?limit=10000&mimetype=application/octet-stream"
    }, {
      test: /\.eot(\?v=\d+\.\d+\.\d+)?$/,
      use: "file-loader"
    }, {
      test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
      use: "url-loader?limit=10000&mimetype=image/svg+xml"
    }, {
      test: require.resolve('jquery'),
      use: 'expose-loader?jQuery!expose-loader?$'
    }]
  }
};
Contact GitHub API Training Shop Blog About
© 2017 GitHub, Inc. Terms Privacy Security Status Help
