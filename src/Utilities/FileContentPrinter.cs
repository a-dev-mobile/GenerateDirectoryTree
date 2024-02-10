public class FileContentPrinter
{
    private readonly IEnumerable<string> _filePaths;
    private readonly string _scanDir;
    private readonly Dictionary<string, int> _fileCharacterCounts = new Dictionary<string, int>();

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
            CountFileCharacters(filePath); // Count characters for each file
        }
        PrintCharacterCounts(); // Print character counts after all files have been processed
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
        Console.WriteLine(); // Adds a blank line for readability
    }

    private void CountFileCharacters(string filePath)
    {
        var relativePath = Path.GetRelativePath(_scanDir, filePath);
        try
        {
            var characterCount = File.ReadAllText(filePath).Length;
            _fileCharacterCounts[relativePath] = characterCount;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"    Failed to read file for character counting: {ex.Message}");
        }
    }
private void PrintCharacterCounts()
{
    const int totalWidth = 80; // Total width for the output
    const int characterCountWidth = 10; // Width allocated for the character count
    const int fileNameWidth = (totalWidth - characterCountWidth) / 2; // Half of the remaining width for the file name
    const int pathWidth = totalWidth - characterCountWidth - fileNameWidth; // The rest for the full path

    Console.WriteLine("--- Character Counts (Descending) ---");
    // Directly use the calculated widths in the format string
    Console.WriteLine($"{"".PadRight(characterCountWidth, ' ')} | {"File Name".PadRight(fileNameWidth, ' ')} | {"Full Path".PadRight(pathWidth, ' ')}");
    Console.WriteLine(new string('-', totalWidth)); // Divider line based on total width

    foreach (var item in _fileCharacterCounts.OrderByDescending(kvp => kvp.Value))
    {
        var fileName = Path.GetFileName(item.Key); // Extracts the file name from the path
        if (fileName.Length > fileNameWidth) // Truncate file name if it's too long
        {
            fileName = fileName.Substring(0, fileNameWidth - 3) + "...";
        }
        var directoryPath = Path.GetDirectoryName(item.Key) ?? ""; // Extracts the directory path, ensuring it's not null
        if (directoryPath.Length > pathWidth) // Truncate path if it's too long
        {
            directoryPath = "..." + directoryPath.Substring(directoryPath.Length - pathWidth + 3);
        }

        // Use string interpolation with alignment specifiers directly
        Console.WriteLine($"{item.Value,characterCountWidth} | {fileName.PadRight(fileNameWidth, ' ')} | {directoryPath.PadRight(pathWidth, ' ')}");
    }
}



}
