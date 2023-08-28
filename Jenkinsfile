podTemplate(containers: [
    containerTemplate(
        name: 'netsdk', 
        image: 'mcr.microsoft.com/dotnet/sdk:6.0', 
        command: 'sleep', 
        args: '30d'
        ),
    // containerTemplate(
    //     name: 'python', 
    //     image: 'python:latest', 
    //     command: 'sleep', 
    //     args: '30d')
  ]) {

    node(POD_LABEL) {
        stage('Build project') {
            git 'https://github.com/haighis/entitydata-apiserver'
            container('netsdk') {
                stage('Build a net project') {
                    sh '''
                    
                    dotnet build src/entiy-data-webapi/entitydata.webapi.csproj
                    //mvn -B -ntp clean package -DskipTests
                    '''
                }
            }
        }
    }
}
// podTemplate(containers: [
//     containerTemplate(
//         name: 'netsdk', 
//         image: 'mcr.microsoft.com/dotnet/sdk:6.0', 
//         command: 'sleep', 
//         args: '30d'
//         ),

//      // containerTemplate(
//      //    name: 'maven', 
//      //    image: 'maven:3.8.1-jdk-8', 
//      //    command: 'sleep', 
//      //    args: '30d'
//      //    ),
// {

//     node(POD_LABEL) {
//         stage('Build .NET project') {
//             //git 'https://github.com/spring-projects/spring-petclinic.git'
//             container('netsdk') {
//                 stage('Build') {
//                     sh '''
//                     echo "dotnet build"
//                     dotnet build src/entiy-data-webapi/entitydata.webapi.csproj
//                     '''
//                 }
//             }
//         }

//         // stage('Get a Maven project') {
//         //     git 'https://github.com/spring-projects/spring-petclinic.git'
//         //     container('maven') {
//         //         stage('Build a Maven project') {
//         //             sh '''
//         //             echo "maven build"
//         //             '''
//         //         }
//         //     }
//         // }

//     }
// }
