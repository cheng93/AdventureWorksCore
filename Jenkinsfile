pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dir(path: 'src/AdventureWorks.Web') {
          bat 'dotnet restore'
        }
        
      }
    }
  }
}