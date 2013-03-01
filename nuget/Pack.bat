del Burrow.*.nupkg

SETLOCAL
SET VERSION=0.0.1

..\src\.nuget\nuget pack Burrow\Package.nuspec -Version %VERSION%
..\src\.nuget\nuget pack Burrow.Extras\Package.nuspec -Version %VERSION%
..\src\.nuget\nuget pack Burrow.RPC\Package.nuspec -Version %VERSION%
ENDLOCAL
pause