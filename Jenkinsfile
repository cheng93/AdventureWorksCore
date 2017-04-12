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
      when  {
        branch 'jenkins-deploy'
      }
      steps {
        dir(path: 'src/AdventureWorks.Web') {
          bat '''del /q "$BUILDS\\AdventureWorks\\*"
              FOR /D %%p IN ("$BUILDS\\AdventureWorks\\*.*") DO rmdir "%%p" /s /q'''
          bat 'dotnet publish -c Release $BUILDS\\AdventureWorks'
        }
      }
    }
  }
}