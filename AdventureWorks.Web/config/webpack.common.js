var webpack = require('webpack');

var path = './Scripts/js/';

module.exports = {
  entry: {
    'polyfills': path + 'polyfills.ts',
    'vendor': path + 'vendor.ts',
    'bundle': path + 'main.ts'
  },

  resolve: {
    extensions: ['.ts']
  },

  module: {
    rules: [
      {
        test: /\.ts$/,
        loaders: [
          {
            loader: 'ts-loader'
          },
          'angular2-template-loader'
        ]
      },
      {
        test: /\.html$/,
        loader: 'html-loader'
      }
    ]
  },

  plugins: [
    new webpack.optimize.CommonsChunkPlugin({
      name: ['bundle', 'vendor', 'polyfills'],
      minChunks: Infinity
    })
  ]
};
