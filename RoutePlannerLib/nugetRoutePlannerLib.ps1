Remove-Item *.nupkg
nuget pack .\RoutePlannerLib.csproj -Symbols -Prop Configuration=Release
nuget push .\Ch.Fhnw.Ecnf.JFTK.RoutePlannerLib.*.nupkg 5e1f774e-7321-47bd-ab10-225e1758a777
read-host -Prompt "Press Enter to continue"