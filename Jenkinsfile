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
                script {
                    sh "docker build -f src/entiy-data-webapi/Dockerfile ."
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
