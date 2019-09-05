pipeline {
    agent any

    stages {
        stage('Build') { 
            steps { 
                echo "Build... $GIT_BRANCH";
                sh "bash ./build.sh " + "$GIT_BRANCH".replaceAll("refs/tags/") + " $Codecov ";
            }
        }
        stage('Deploy') {
            when {
                 expression { return "$GIT_BRANCH".startsWith("refs/tags/") }
            }
            steps {
                echo "Deploying.... $NuGetKey";
                sh 'cd ./ngpkgs; ls | grep ".nupkg$" | { while read -r nupkg; do eval "dotnet nuget push $nupkg -k $NuGetKey -s https://www.nuget.org/;"; done }';
            }
        }
    }
}