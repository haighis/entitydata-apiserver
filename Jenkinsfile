pipeline {
    agent any
    stages {
        stage('Build NET Project') {
            steps {
                echo 'Building..'
                // container('docker') {
                //     sh 'docker build -t fluence/portaltest .'
                // }
                 dir('src/entiy-data-webapi/') {
                     sh(script: 'dotnet build entitydata.webapi.csproj', returnStdout: true);
                 }    
            }

        }
        stage('Build NET Project 2') {
            steps {
                echo 'Building 1..'
                // container('docker') {
                //     sh 'docker build -t fluence/portaltest .'
                // }
                 dir('src/entiy-data-webapi/') {
                     sh(script: 'dotnet build entitydata.webapi.csproj', returnStdout: true);
                 }    
            }
            steps {
                echo 'Test..'
                // container('docker') {
                //     sh 'docker build -t fluence/portaltest .'
                // }
                 dir('src/entiy-data-webapi/') {
                     sh(script: 'dotnet build entitydata.webapi.csproj', returnStdout: true);
                 }    
            }
        }
    }
}