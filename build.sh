# Read Version
version=$1

# Output Path
path=$(pwd)
path="$path/ngpkgs"

# Remove Old Output
rm -R -f $path

# Restore Projects
find . -type d | grep '^./XPY.ToolKit.[^/]*$' | { while read -r project; do eval "dotnet restore $project;"; done }

# Unit Test
find . -type d | grep '^./XPY.ToolKit.[^/]*$' | grep '\b\.Test$' | { while read -r project; do eval "dotnet test $project /p:CollectCoverage=true;"; done }

# Codecov
cat ./codecov.sh | bash -s - -f "*/coverage.json" -t $2

# Pack
find . -type d | grep '^./XPY.ToolKit.[^/]*$' | grep -v '\b\.Test$' | { while read -r project; do eval "dotnet build $project; "; done }

# Pack
find . -type d | grep '^./XPY.ToolKit.[^/]*$' | grep -v '\b\.Test$' | { while read -r project; do eval "dotnet pack $project -p:Version=$version --output $path; "; done }