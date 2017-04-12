#!groovy 
pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        bat 'dotnet restore'
        dir(path: 'src/AdventureWorks.Web') {
          bat 'dotnet build -c Release'
        }
      }
    }
    stage('Test - Aop') {
      steps {
        dir(path: 'tests/AdventureWorks.Aop.Tests') {
          bat 'dotnet xunit'
        }
      }
    }
    stage('Deploy') {
      steps {
        echo '${GIT_BRANCH}'
      }
    }
  }
}