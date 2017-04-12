#!groovy 
pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        bat 'dotnet restore'
        dir(path: 'src/AdventureWorks.Web') {
          bat 'dotnet build -c Release'
          bat 'npm install'
          bat 'npm run build'
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
        branch 'master'
      }
      steps {
        dir(path: 'src/AdventureWorks.Web') {
          bat '''del /q "%builds%\\AdventureWorks\\*"
              FOR /D %%p IN ("%builds%\\AdventureWorks\\*.*") DO rmdir "%%p" /s /q'''
          bat 'dotnet publish AdventureWorks.Web.csproj -c Release -o %builds%\\AdventureWorks'
        }
      }
    }
  }
}