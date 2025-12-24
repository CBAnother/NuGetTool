# NuGetTool

The NuGetTool is a WPF application designed to simplify the creation and publishing of NuGet packages.

## How to Run
1. Navigate to the project directory: `NuGetTool`
2. Build the Solution:
   ```powershell
   dotnet build
   ```
3. Run the WPF Tool:
   ```powershell
   cd NuGetTool
   dotnet run
   ```

## Project Structure
- **NuGetTool**: WPF GUI Application.
- **NuGetTool.Core**: Class Library containing business logic (Data models, Nuspec/CSPROJ generation, Pack/Push commands).

## Usage

### Mode Selection
- **Nuspec Mode**: Uses `NuGet.exe` and a `.nuspec` file. Best for legacy or manual file control.
- **CSPROJ Mode**: Uses `dotnet` CLI and a dynamically generated `.csproj`. Best for modern workflows.

### Steps
1. **Select Files**: Click "Add Files..." or drag and drop files into the list.
2. **Review Metadata**:
   - **Package ID**: Auto-populated from the first file name.
   - **Version**: Auto-populated from the first file's last write time (`yyyy.MM.dd`).
   - **Authors/Description**: Optional fields.
3. **Generate Spec (Optional)**:
   - Click "Generate Nuspec" or "Generate CSPROJ" to review the generated file on disk (`Package.nuspec` or `Package.csproj`).
4. **Build Package**:
   - Click "Build Package".
   - The tool will run `nuget pack` or `dotnet pack`.
   - Check the Log area for output (Success/Error).
5. **Upload Package**:
   - Click "Upload Package".
   - The tool will run `nuget push` or `dotnet nuget push`.
