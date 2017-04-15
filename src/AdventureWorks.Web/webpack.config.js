function buildConfig(env) {
  return require('./webpack/webpack.' + env + '.js');
}

module.exports = buildConfig;