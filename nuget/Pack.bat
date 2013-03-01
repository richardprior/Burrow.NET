del Burrow.*.nupkg

SETLOCAL
SET VERSION=0.0.1

Nuget\nuget pack Burrow\Package.nuspec -Version %VERSION%
Nuget\nuget pack Burrow.Extras\Package.nuspec -Version %VERSION%
Nuget\nuget pack Burrow.RPC\Package.nuspec -Version %VERSION%
ENDLOCAL
pause