# NuGetTool GUI Application Plan

## Goal Description
Create a WPF GUI application in `NuGetTool` to facilitate creating, packing, and pushing NuGet packages.
The app will allow two modes:
1. **Nuspec Mode**: Select files, generate `.nuspec`, use `nuget.exe` to pack and push.
2. **CSPROJ Mode**: Select files, generate a temporary `.csproj`, use `dotnet pack` and `dotnet nuget push`.

## User Review Required
> [!NOTE]
> I will assume `NuGet.exe` is located at `..\DownloadNuget\NuGet.exe` relative to the tool or the working directory. I will try to detect it or allow the user to specify the path if not found.

> [!IMPORTANT]
> Default version format will be based on the file date. I will use `yyyy.MM.dd` or similar to ensure valid NuGet versioning.

## Proposed Changes

### NuGetTool
#### [NEW] [NuGetTool.csproj](file:///c:/dev/packages/nuget/NuGetTool/NuGetTool.csproj)
- TargetFramework: `net9.0-windows`
- UseWPF: `true`

#### [NEW] [App.xaml](file:///c:/dev/packages/nuget/NuGetTool/App.xaml)
- Standard WPF App definition.

#### [NEW] [MainWindow.xaml](file:///c:/dev/packages/nuget/NuGetTool/MainWindow.xaml)
- **Mode Selection**: RadioButtons/Tabs for "File Base (Nuspec)" vs "Project Base (CSPROJ)".
- **File Base UI**:
    - **Files Selection**: Button to add files. ListBox/DataGrid to show selected files.
    - **Package Metadata**: ID, Version, Authors, Description.
    - **Generate Nuspec**: Button.
- **Project Base UI** (Same as File Base now, reuse UI):
    - Reusing File Selection list for dynamic generation.
    - If user wants to point to existing csproj, maybe a "Load existing" option, but request implies "create a csproj". I will support dynamic creation primarily.
- **Common/Shared UI**:
    - **Build Package**: Button (trigger `nuget pack` or `dotnet pack`).
    - **Upload Package**: Button (trigger `nuget push` or `dotnet nuget push`).
- **Log/Output**: TextBox.

#### [NEW] [MainWindow.xaml.cs](file:///c:/dev/packages/nuget/NuGetTool/MainWindow.xaml.cs)
- Logic to handle UI events.
- **Switch Mode**: Toggle visibility of UI elements.
- **Nuspec Mode**:
    - `GenerateNuspec`: Writes XML.
    - `BuildPackage`: `NuGet.exe pack <nuspec>`.
    - `UploadPackage`: `NuGet.exe push <nupkg> -Source ...`.
- **CSPROJ Mode**:
    - `GenerateCsproj`: Writes a `.csproj` file dynamically.
      - `<Project Sdk="Microsoft.NET.Sdk">`
      - `<PropertyGroup>...PackageId...</PropertyGroup>`
      - `<ItemGroup><Content Include="..." Pack="true" PackagePath="contentFiles/any/any/%(Filename)%(Extension)" PackageCopyToOutput="true" /></ItemGroup>`
    - `BuildPackage`: `dotnet pack <generated_csproj>`.
    - `UploadPackage`: `dotnet nuget push <nupkg>`.

## Refactoring Plan (Core Separation)
### Goal
Extract business logic into `NuGetTool.Core` to allow reuse in Blazor apps.

### Proposed Changes
#### [NEW] [NuGetTool.Core](file:///c:/dev/packages/nuget/NuGetTool.Core/NuGetTool.Core.csproj)
- **Project Type**: Class Library (`net9.0`).
- **Classes**:
    - `PackageMetadata`: Data model for ID, Version, Authors, Description, Files.
    - `PackageService`:
        - `GenerateNuspec(PackageMetadata data, string outputPath)`
        - `GenerateCsproj(PackageMetadata data, string outputPath)`
        - `BuildPackage(string projectPath, bool isNuspec, string nugetExePath = null)`
        - `UploadPackage(string packagePath, bool isNuspec, string source, string nugetExePath = null)`

#### [MODIFY] [MainWindow.xaml.cs](file:///c:/dev/packages/nuget/NuGetTool/MainWindow.xaml.cs)
- Remove `GenerateNuspec`, `GenerateCsproj`, logic inside `BtnBuild_Click`, `BtnUpload_Click`.
- Use `PackageService` from `NuGetTool.Core`.

#### [NEW] [NuGetTool.sln](file:///c:/dev/packages/nuget/NuGetTool.sln)
- Solutions containing both projects.

## Verification Plan

### Manual Verification
1.  Run the application.
2.  Select a dummy DLL or text file.
3.  Verify "Package ID" is auto-filled.
4.  Verify "Version" is auto-filled with file date.
5.  Click "Generate Nuspec" and verify `Package.nuspec` is created in the output dir (or selected dir) and matches the expected format (checking `contentFiles` entries).
6.  Click "Build Package" and verify `.nupkg` is generated.
7.  Click "Upload Package" (might fail if no valid source/key, but check does it try to run the command).
