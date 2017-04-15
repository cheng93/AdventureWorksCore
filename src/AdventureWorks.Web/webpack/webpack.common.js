const webpack = require('webpack');
const path = require('path');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

var root = './Scripts/js/';
var exclusionRegex = [/node_modules/];

module.exports = {
  entry: {
    'vendor.angular': root + 'angular/vendor.ts',
    'app.angular': root + 'angular/main.ts',

    'vendor.react': root + 'react/vendor.js',
    'app.react': root + 'react/main.jsx'
  },

  output: {
    path: path.resolve(__dirname, '../wwwroot/'),
    publicPath: '/../',
    filename: './js/[name].js'
  },

  resolve: {
    extensions: ['.ts', '.js', '.jsx']
  },

  module: {
    rules: [
      {
        test: /\.tsx?$/,
        loaders: ['babel-loader', 'awesome-typescript-loader', 'angular2-template-loader'],
        exclude: exclusionRegex
      },
      {
        test: /\.jsx?$/,
        loaders: ['babel-loader'],
        exclude: exclusionRegex
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
