#For local/manual report -> powershell / bash command window
#1 type cmd in UserStories.AcceptanceTests folder
#2 copy-paste the following command and set a value for <file_route>
dotnet test UserStories.AcceptanceTests -l:trx;LogFileName=<file_route>\TestOutput.xml