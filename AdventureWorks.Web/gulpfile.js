var gulp = require('gulp');
var cleanCss = require('gulp-clean-css');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');

var browserify = require('browserify');
var rimraf = require('rimraf');
var tsify = require('tsify');
var vinyl = require('vinyl-source-stream');

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
  js: paths.scripts + './**/*.js'
};

var node_modules = [
  angular = {
    name: 'angular',
    base: paths.node_modules + './@angular/core/bundles/',
    get src() {
      return this.base + './core.umd.js'
    }
  },
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

gulp.task('js', ['clean:js'], function () {
  gulp.src(scripts.js)
    .pipe(uglify())
    .pipe(concat('script.js'))
    .pipe(gulp.dest(wwwroot.js));
});

gulp.task('ts', ['clean:js'], function () {
  browserify({
    basedir: '.',
    debug: true,
    entries: ['Scripts/js/main.ts'],
    cache: {},
    packageCache: {}
  })
  .plugin(tsify)
  .bundle()
  .pipe(vinyl('bundle.js'))
  .pipe(gulp.dest(wwwroot.js));
});

gulp.task('scripts', ['css', 'js', 'ts']);

gulp.task('copy', ['clean:lib'], function () {
  node_modules.forEach(function (module) {
    gulp.src(module.src, { base: module.base })
      .pipe(gulp.dest(wwwroot.lib + module.name))
  }, this);
});

gulp.task('build', ['scripts', 'copy']);