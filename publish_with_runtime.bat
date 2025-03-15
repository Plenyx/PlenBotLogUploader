dotnet publish -c Release -r win-x64 -P:PublishSingleFile=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true
