// REFERENCE 
// - https://e.printstacktrace.blog/jenkins-pipeline-environment-variables-the-definitive-guide/
// - http://localhost:8787/env-vars.html
pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                 // dir('src/entiy-data-webapi/') {
                 //     sh(script: 'dotnet build entitydata.webapi.csproj', returnStdout: true);
                 // }    
            }
        }

         stage ('Unit Tests') {
            steps {
                echo 'Run csharp code unit tests'
            }
        }   

           stage ('Unit Tests - SonarQube Analysis') {
            steps {
                echo 'Run sonarqube analysis to analyze unit test coverage. Send unit test coverage report url in email or teams integration to Team'
            }
        }   

        stage("Build & Publish Docker Image") {
            steps {
                
                dir('src/entiy-data-webapi/') {
                    sh "docker build -t entity-data-server ."
                    sh "docker tag entity-data-server haighis/entity-data-server:1.0.$BUILD_NUMBER"
                    withEnv(["DOCKER_USER=${DOCKER_USER}","DOCKER_PASSWORD=${DOCKER_PASSWORD}"]) {    
                        sh "docker login -u ${DOCKER_USER} -p ${DOCKER_PASSWORD}"
                        sh "docker push haighis/entity-data-server:1.0.$BUILD_NUMBER"
                    }
                }
            }
        }
        
        
        stage ('Deploy to staging url') {
            steps {
                echo 'Flux/ArgoCD integration. For now we can just talk to k8s directly and write kubectl commands to deploy new docker images'
            }
        }        

        
        stage ('QA Automation Analysis') {
            steps {
                echo 'This will: 1) run all qa automation such as end to end tests such as Playwright, Selenium, 2) Store results in postgres, 3) analyze results with prior run '
                echo 'if results do not meet minimum threshold 100 percent then qa automation fails. If this is production then we do not proceed to production deploy step '
            }
        }

        stage ('Send QA Automation Report') {
            steps {
                echo 'Send an email with link to qa automation report.'
            }
        }

        
        stage ('Deploy to Production') {
            steps {
                echo 'If this is a release branch then we can deploy to production. Else we are in develop branch so we deploy to develop url. '
                echo 'Flux/ArgoCD integration. For now we can just talk to k8s directly and write kubectl commands to deploy new docker images'
            }
        }        
    }
}
