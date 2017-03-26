var gulp = require('gulp');
var cleanCss = require('gulp-clean-css');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');

var webpack = require('webpack');
var config = require('./webpack.config.js');

var rimraf = require('rimraf');

var paths = {
  wwwroot: './wwwroot/',
  scripts: './Scripts/',
  node_modules: './node_modules/'
};

var wwwroot = {
  css: paths.wwwroot + './css/',
  js: paths.wwwroot + './js/',
  lib: paths.wwwroot + './lib/'
};

var scripts = {
  css: paths.scripts + './**/*.css',
  js: paths.scripts + './js/'
};

var node_modules = [
  bootstrap = {
    name: 'bootstrap',
    base: paths.node_modules + './bootstrap/dist/',
    get src() {
      return [
        this.base + './css/*.css',
        this.base + './fonts/*.*',
      ]
    }
  }
]

gulp.task('clean:css', function (cb) {
  rimraf(wwwroot.css, cb);
});

gulp.task('clean:js', function (cb) {
  rimraf(wwwroot.js, cb);
});

gulp.task('clean:lib', function (cb) {
  rimraf(wwwroot.lib, cb);
});

gulp.task('css', ['clean:css'], function () {
  gulp.src(scripts.css)
    .pipe(concat('sites.min.css'))
    .pipe(cleanCss())
    .pipe(gulp.dest(wwwroot.css));
});

gulp.task('ts', ['clean:js'], function (callback) {
  webpack(config).run(callback);
});

gulp.task('scripts', ['css', 'ts']);

gulp.task('copy', ['clean:lib'], function () {
  node_modules.forEach(function (module) {
    gulp.src(module.src, { base: module.base })
      .pipe(gulp.dest(wwwroot.lib + module.name))
  }, this);
});

gulp.task('build', ['scripts', 'copy']);