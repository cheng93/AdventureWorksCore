pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        git(url: 'git@github.com:cheng93/AdventureWorksCore.git', branch: 'jenkins', changelog: true, poll: true)
      }
    }
  }
}