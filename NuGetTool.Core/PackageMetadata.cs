using System.Collections.Generic;

namespace NuGetTool.Core;

public class PackageMetadata
{
    public string Id { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string Authors { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> ContentFiles { get; set; } = new();
}
