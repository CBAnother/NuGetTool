# NuGetTool GUI Creation

- [x] Initialize WPF Project in `c:\dev\packages\nuget\NuGetTool` <!-- id: 1 -->
- [x] Create Implementation Plan <!-- id: 2 -->
- [x] Design UI (MainWindow.xaml) <!-- id: 3 -->
- [x] Implement Application Logic (MainWindow.xaml.cs) <!-- id: 4 -->
    - [x] File Selection logic <!-- id: 5 -->
    - [x] Nuspec generation logic (default name, version, contentFiles) <!-- id: 6 -->
    - [x] Pack logic (call NuGet.exe pack or dotnet pack) <!-- id: 7 -->
    - [x] Push logic (call NuGet.exe push or dotnet nuget push) <!-- id: 8 -->
    - [x] Implement Dotnet CLI (CSPROJ) mode support <!-- id: 10 -->
        - [x] Dynamic CSPROJ generation logic <!-- id: 11 -->
- [x] Verify Application <!-- id: 9 -->
- [ ] Refactor: Separate Core Logic <!-- id: 12 -->
    - [x] Create `NuGetTool.Core` Class Library <!-- id: 13 -->
    - [x] Create Solution and link projects <!-- id: 14 -->
    - [x] Move Logic to `NuGetTool.Core` (PackageService) <!-- id: 15 -->
    - [x] Update `NuGetTool` (WPF) to use Core <!-- id: 16 -->
    - [x] Verify Refactoring <!-- id: 17 -->
