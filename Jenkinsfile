pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                 dir('src/entiy-data-webapi/') {
                     sh(script: 'dotnet build entitydata.webapi.csproj', returnStdout: true);
                 }    
            }
        }

        stage("Build Docker Image") {
            steps {
                
                dir('src/entiy-data-webapi/') {
                    sh "docker build -t entity-data-server ."
                    sh "docker tag entity-data-server haighis/entity-data-server:1.0.2"
                    
                    //sh "docker push haighis/entity-data-server:1.0.2"
                }
            }
        }
        
        stage ('Unit Tests') {
            steps {
                echo 'Testing'
            }
        }        

        
        stage ('Deploy') {
            steps {
                echo 'Testing'
            }
        }        

        
        stage ('QA Automation') {
            steps {
                echo 'Testing'
            }
        }        
    }
}
