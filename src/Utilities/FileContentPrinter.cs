public class FileContentPrinter
{
    private readonly IEnumerable<string> _filePaths;
    private readonly string _scanDir;

    public FileContentPrinter(IEnumerable<string> filePaths, string scanDir)
    {
        _filePaths = filePaths;
        _scanDir = scanDir;
    }

    public void PrintFilesContent()
    {
        Console.WriteLine("\n--- File Contents ---");
        foreach (var filePath in _filePaths)
        {
            PrintFileContentsWithHeader(filePath);
        }
    }

    private void PrintFileContentsWithHeader(string filePath)
    {
        var relativePath = Path.GetRelativePath(_scanDir, filePath);
        Console.WriteLine($"\n--- File: {relativePath} ---");
        PrintFileContents(filePath);
    }

    private void PrintFileContents(string filePath)
    {
        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                Console.WriteLine($"    {line}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    Failed to read file: {ex.Message}");
        }
        Console.WriteLine(); // Improve readability with a blank line after file content.
    }
}
