pipeline {
    agent any
    stages {
        stage('Build NET Project') {
            steps {
                echo 'Building..'
                // container('docker') {
                //     sh 'docker build -t fluence/portaltest .'
                // }
                 dir('src/') {
                     sh(script: 'dotnet build src/entiy-data-webapi/entitydata.webapi.csproj', returnStdout: true);
                 }    
            }
        }
    }
}