Get-ChildItem  *.csproj -recurse -Verbose | ForEach { dotnet restore $_.FullName }
dotnet build -r linux-arm -o ../../build