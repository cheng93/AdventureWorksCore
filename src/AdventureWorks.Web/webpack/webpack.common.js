const webpack = require('webpack');
const path = require('path');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

var root = './Scripts/js/';
var node_modules_condition = /node_modules/;
var angular_condition = path.resolve(__dirname, '../Scripts/js/angular/');

module.exports = {
  entry: {
    'vendor.angular': root + 'angular/vendor.ts',
    'app.angular': root + 'angular/main.ts',

    'vendor.react': root + 'react/vendor.js',
    'app.react': root + 'react/main.tsx'
  },

  output: {
    path: path.resolve(__dirname, '../wwwroot/'),
    publicPath: '/../',
    filename: './js/[name].js'
  },

  resolve: {
    extensions: ['.ts', '.js', '.jsx', '.tsx']
  },

  module: {
    rules: [
      {
        test: /\.tsx?$/,
        loaders: ['babel-loader', 'awesome-typescript-loader', 'angular2-template-loader'],
        exclude: node_modules_condition,
        include: angular_condition
      },
      {
        test: /\.tsx?$/,
        loaders: ['babel-loader', 'awesome-typescript-loader'],
        exclude: {
          or: [node_modules_condition, angular_condition]
        }
      },
      {
        test: /\.jsx?$/,
        loaders: ['babel-loader'],
        exclude: node_modules_condition
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
    new webpack.ContextReplacementPlugin(
      /angular(\\|\/)core(\\|\/)@angular/,
      path.resolve(root),
      {}
    ),
    new webpack.optimize.CommonsChunkPlugin({
      names: ['vendor.react'],
      chunks: ['app.react', 'vendor.react'],
      minChunks: Infinity
    }),
    new webpack.optimize.CommonsChunkPlugin({
      names: ['vendor.angular'],
      chunks: ['app.angular', 'vendor.angular'],
      minChunks: Infinity
    }),
    new ExtractTextPlugin({
      filename: './css/[name].css',
      allChunks: true
    })
  ]
};
