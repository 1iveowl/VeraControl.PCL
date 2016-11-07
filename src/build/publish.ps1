$msbuild = join-path -path (Get-ItemProperty "HKLM:\software\Microsoft\MSBuild\ToolsVersions\14.0")."MSBuildToolsPath" -childpath "msbuild.exe"
&$msbuild ..\main\IVeraControl.PCL\IVeraControl.PCL.csproj /t:Build /p:Configuration="Release"
&$msbuild ..\main\VeraControl.PCL\VeraControl.PCL.csproj /t:Build /p:Configuration="Release"
&$msbuild ..\main\VeraControl.PCL\Foundation\VeraControl.NET\VeraControl.NET.csproj /t:Build /p:Configuration="Release"
&$msbuild ..\main\VeraControl.PCL\CrossPlatform\VeraControl.Android\VeraControl.Android.csproj  /t:Build /p:Configuration="Release"
&$msbuild ..\main\VeraControl.PCL\CrossPlatform\VeraControl.iOS\VeraControl.iOS.csproj /t:Build /p:Configuration="Release"
&$msbuild ..\main\VeraControl.PCL\CrossPlatform\VeraControl.UWP\VeraControl.UWP.csproj /t:Build /p:Configuration="Release"
&$msbuild ..\main\Upnp\UpnpModels\UpnpModels.csproj /t:Build /p:Configuration="Release"

$version = [Reflection.AssemblyName]::GetAssemblyName((resolve-path '..\main\IVeraControl.PCL\bin\Release\IVeraControl.dll')).Version.ToString(3)
Remove-Item .\NuGet -Force -Recurse
New-Item -ItemType Directory -Force -Path .\NuGet
NuGet.exe pack ..\main\VeraControl.PCL\VeraControl.PCL.nuspec -Verbosity detailed -Symbols -OutputDir "NuGet" -Version $version
Nuget.exe push .\Nuget\VeraControl.PCL.$version.symbols.nupkg -Source https://www.nuget.org