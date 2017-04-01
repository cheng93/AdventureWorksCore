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
    css: [
      paths.node_modules + './bootstrap/dist/css/bootstrap.css'
    ],
    misc: {
      folder: 'fonts',
      src: [
        paths.node_modules + './bootstrap/dist/fonts/*.*',
      ]
    }
  },
  fontawesome = {
    name: 'font-awesome',
    css: [
      paths.node_modules + './font-awesome/css/font-awesome.css'
    ],
    misc: {
      folder: 'fonts',
      src: [
        paths.node_modules + './font-awesome/fonts/*.*'
      ]
    }
  },
  primeng = {
    name: 'primeng',
    css: [
      paths.node_modules + './primeng/components/**/*.css',
      paths.node_modules + './primeng/resources/themes/bootstrap/*.css',
    ]
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
    .pipe(concat('sites.css'))
    .pipe(cleanCss())
    .pipe(gulp.dest(wwwroot.css));
});

gulp.task('ts', ['clean:js'], function (callback) {
  webpack(config).run(callback);
});

gulp.task('scripts', ['css', 'ts']);

gulp.task('lib:css', ['clean:lib'], function () {
  node_modules.forEach(function (module) {
    gulp.src(module.css)
      .pipe(concat(module.name + '.css'))
      .pipe(cleanCss())
      .pipe(gulp.dest(wwwroot.lib + module.name + '/css/'))
  }, this);
});

gulp.task('lib:misc', ['clean:lib'], function () {
  node_modules.forEach(function (module) {
    if (module.misc) {
      gulp.src(module.misc.src)
        .pipe(gulp.dest(wwwroot.lib + module.name + '/' + module.misc.folder + '/'))
    }
  }, this);
});

gulp.task('lib', ['lib:css', 'lib:misc']);

gulp.task('build', ['scripts', 'lib']);