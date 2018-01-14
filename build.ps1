#Get-ChildItem  *.csproj -recurse -Verbose | ForEach { dotnet restore $_.FullName }
#dotnet build -r linux-arm -o ../../build

# Update HomeAutomationAPI
# Run dotnet run on HomeAutomationServer project, then run this command
autorest --namespace=HomeAutomationClient --input-file=http://localhost:59110/swagger/v1/swagger.json --output-folder=.\src\HomeAutomationClient --csharp --add-credentials=true