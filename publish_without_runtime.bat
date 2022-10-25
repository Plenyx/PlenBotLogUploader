dotnet publish -c Release -r win-x64 --self-contained=false -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true -o artifacts/uploader/win64/
