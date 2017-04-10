const webpack = require('webpack');
const path = require('path');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

var root = './Scripts/js/';

module.exports = {
  entry: {
    'polyfills': root + 'polyfills.ts',
    'vendor': root + 'vendor.ts',
    'app': root + 'main.ts'
  },

  output: {
    path: path.resolve(__dirname, '../wwwroot/'),
    publicPath: '/../',
    filename: './js/[name].js'
  },

  resolve: {
    extensions: ['.ts', '.js']
  },

  module: {
    rules: [
      {
        test: /\.tsx?$/,
        loaders: ['ts-loader', 'angular2-template-loader']
      },
      {
        test: /\.html$/,
        loader: 'html-loader'
      },
      {
        test: /\.css$/,
        use: ExtractTextPlugin.extract({
          use: "css-loader"
        })
      },
      {
        test: /\.(eot|svg|ttf|woff|woff2)$/,
        loader: "file-loader?name=fonts/[name].[ext]"
      },
      {
        test: /\.(png|gif)$/,
        loader: "file-loader?name=images/[name].[ext]"
      }
    ]
  },

  plugins: [
    new webpack.optimize.CommonsChunkPlugin({
      name: ['app', 'vendor', 'polyfills'],
      minChunks: Infinity
    }),
    new ExtractTextPlugin('./css/[name].css')
  ]
};
