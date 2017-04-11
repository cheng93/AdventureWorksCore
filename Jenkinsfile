pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dir(path: 'src/AdventureWorks.Web') {
          bat 'dotnet restore'
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
  }
}