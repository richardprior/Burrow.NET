& .\src\.nuget\nuget.exe u .\src\Burrow.sln

$files = gci -Path .\src -Filter packages.config -Recurse 
$files | ForEach-Object {
    & .\src\.nuget\nuget.exe i $_.FullName -SolutionDirectory .\src
}