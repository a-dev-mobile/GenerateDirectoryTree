public class FileContentPrinter
{
    private readonly IEnumerable<string> _filePaths;
    private readonly string _scanDir;

    public FileContentPrinter(IEnumerable<string> filePaths, string scanDir)
    {
        _filePaths = filePaths;
        _scanDir = scanDir;
    }

    // Prints the contents of each file, preceded by a header with the relative file path
    public void PrintFilesContent()
    {
        Console.WriteLine("\n--- File Contents ---");
        foreach (var filePath in _filePaths)
        {
            PrintFileContentsWithHeader(filePath);
        }
    }

    // Prints a header with the file's relative path before printing its contents
    private void PrintFileContentsWithHeader(string filePath)
    {
        var relativePath = Path.GetRelativePath(_scanDir, filePath);
        Console.WriteLine($"\n--- File: {relativePath} ---");
        PrintFileContents(filePath);
    }

    // Reads and prints the contents of a file, handling potential errors gracefully
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
        Console.WriteLine(); // Adds a blank line for better readability after printing a file's content
    }
}
