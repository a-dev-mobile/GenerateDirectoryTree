public class DirectoryScanner
{
    private readonly string _scanDir;
    private readonly HashSet<string> _excludeItems;

    public List<string> FilePathsToDisplay { get; } = new List<string>();

    public DirectoryScanner(string scanDir, IEnumerable<string> excludeItems)
    {
        _scanDir = scanDir;
        _excludeItems = new HashSet<string>(excludeItems, StringComparer.OrdinalIgnoreCase);
    }

    public void ScanAndPrintDirectoryTree()
    {
        if (!Directory.Exists(_scanDir))
        {
            Console.WriteLine($"Error: The specified scan directory '{_scanDir}' does not exist.");
            return;
        }

        Console.WriteLine($"{new DirectoryInfo(_scanDir).Name}/");
        PrintDirectoryTree(_scanDir, "");
    }

    private void PrintDirectoryTree(string dirPath, string indent)
    {
        var entries = Directory.EnumerateFileSystemEntries(dirPath).Where(entry => !_excludeItems.Contains(Path.GetFileName(entry)));

        foreach (var entry in entries)
        {
            var isDirectory = Directory.Exists(entry);
            var name = Path.GetFileName(entry);
            Console.WriteLine($"{indent}{(isDirectory ? "├── [D] " : "├── [F] ")}{name}");

            if (isDirectory)
            {
                PrintDirectoryTree(entry, indent + "│   ");
            }
            else
            {
                FilePathsToDisplay.Add(entry);
            }
        }
    }
}
