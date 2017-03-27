var webpackMerge = require('webpack-merge');
var commonConfig = require('./webpack.common.js');
var path = require('path');

module.exports = webpackMerge(commonConfig, {
    devtool: 'inline-source-map',
    output: {
        path: path.resolve(__dirname, '../wwwroot/js/'),
        filename: '[name].js'
    }
});