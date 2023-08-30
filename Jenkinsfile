pipeline {
    agent any
    stages {
        stage('Build') {
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

        stage("build image") {
            steps {
                dir('src/entiy-data-webapi/') {
                    sh "docker build ."
                }
            }
        }
        
        // stage ('Test') {
        //     steps {
        //         echo 'Testing'
        //     }
        // }        
    }
}
