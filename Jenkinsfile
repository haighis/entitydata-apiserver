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
    }
}