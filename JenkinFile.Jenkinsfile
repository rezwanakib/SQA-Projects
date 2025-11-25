pipeline{
    agent any

    environment {
        FILE_NAME = "data.txt"
    }

    stages {
        stage('Create File') {
            steps {
                echo 'Creating a sample file...'
                writeFile file: env.FILE_NAME, text: "This is a sample file created in Jenkins pipeline."
            }
        }

        stage('Read File') {
            steps {
                echo 'Reading the content of the file...'
                script {
                    def fileContent = readFile(env.FILE_NAME)
                    echo "File Content:\n${fileContent}"

                    if(fileContent.contains("sample")){
                        echo "The file contains the word 'sample'."
                    } else {
                        echo "The word 'sample' was not found in the file."
                    }
                }
            }
        }
    }

    post {
        always {
            echo 'Pipeline finished.'
            cleanWs()
        }
    }


}
