pipeline {
    agent any

    options {
        buildDiscarder(logRotator(numToKeepStr: '10', daysToKeepStr: '7'))
    }

    parameters {
        booleanParam(name: 'RUN_TESTS', defaultValue: true, description: 'Set true to run tests')
    }

    stages {
        stage('Prepare Workspace') {
            steps {
                echo 'Cleaning workspace before starting build...'
                cleanWs()
            }
        }

        stage('Checkout') {
            steps {
                echo 'Checking out source code from repository...'
                checkout scm
            }
        }

        stage('Setup Allure Environment') {
            when {
                expression { return params.RUN_TESTS }
            }
            steps {
                echo 'Setting up Allure environment...'
                script {
                    // Ensure allure-results folder exists
                    bat "if not exist \"${projectName}/allure-results\" mkdir \"${projectName}/allure-results\""

                    // Pre-test environment file (optional)
                    def envFile = "${projectName}/allure-results/environment.properties"
                    writeFile file: envFile, text: """
                    BuildNumber=${currentBuild.number}
                    Node=${env.NODE_NAME}
                    RunTestsParam=${params.RUN_TESTS}
                    ProjectName=${projectName}
                    JenkinsURL=${env.JENKINS_URL}
                    """
                }
            }
        }

        stage('Build & Run Tests') {
            when {
                expression { return params.RUN_TESTS }
            }
            steps {
                echo 'Building and running TestNG tests...'
                bat 'mvn clean install'
            }
        }
    }

    post {
        always {
            script {
                if (params.RUN_TESTS) {

                    echo "Updating Allure environment with final build result..."

                    // Update environment file (does not delete test results)
                    def envFile = "${projectName}/allure-results/environment.properties"
                    writeFile file: envFile, text: """
                    BuildNumber=${currentBuild.number}
                    BuildResult=${currentBuild.result ?: 'SUCCESS'}
                    Node=${env.NODE_NAME}
                    RunTestsParam=${params.RUN_TESTS}
                    ProjectName=${projectName}
                    JenkinsURL=${env.JENKINS_URL}
                    ExecutionTime=${new Date().format('yyyy-MM-dd HH:mm:ss')}
                    """

                    // Add executor info
                    def executorFile = "${projectName}/allure-results/executor.json"
                    writeFile file: executorFile, text: """
                    {
                      "name": "${env.JOB_NAME}",
                      "type": "CI",
                      "url": "${env.BUILD_URL}",
                      "buildOrder": ${currentBuild.number},
                      "reportUrl": "${env.BUILD_URL}allure"
                    }
                    """

                    // Copy history folder if exists to maintain trends
                    def historySrc = "${projectName}/allure-report/history"
                    def historyDest = "${projectName}/allure-results/history"
                    if (fileExists(historySrc)) {
                        bat "xcopy /E /I /Y \"${historySrc}\" \"${historyDest}\""
                    }

                    echo "Generating Allure report..."
                    allure includeProperties: true, results: [[path: "${projectName}/allure-results/"]]

                    echo "Archiving Allure results..."
                    archiveArtifacts artifacts: "${projectName}/allure-results/**", fingerprint: true

                } else {
                    echo "RUN_TESTS not selected, failing the build."
                    error("RUN_TESTS was not selected. Failing the build")
                }

                echo "Build number is ${currentBuild.number}"
                echo "Build result: ${currentBuild.result}"
                echo "Running on node: ${env.NODE_NAME}"
            }
        }
    }
}
