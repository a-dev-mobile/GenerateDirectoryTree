using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

    // Scans the specified directory and prints the directory tree structure
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

    // Recursively prints the directory tree, applying indentation for subdirectories and excluding specified items
    private void PrintDirectoryTree(string dirPath, string indent)
    {
        var entries = Directory.EnumerateFileSystemEntries(dirPath).Where(entry => !_excludeItems.Contains(Path.GetFileName(entry))).ToList();

        for (int i = 0; i < entries.Count; i++)
        {
            var entry = entries[i];
            var isDirectory = Directory.Exists(entry);
            var name = Path.GetFileName(entry);
            var prefix = i == entries.Count - 1 ? "└──" : "├──";

            if (isDirectory)
            {
                Console.ForegroundColor = ConsoleColor.Blue; // Directories are highlighted in blue
                Console.WriteLine($"{indent}{prefix} {name}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{indent}{prefix} {name}"); // Files are printed in default color
            }

            if (isDirectory)
            {
                var newIndent = i == entries.Count - 1 ? indent + "    " : indent + "│   ";
                PrintDirectoryTree(entry, newIndent);
            }
            else
            {
                FilePathsToDisplay.Add(entry); // Collect file paths for possible content display later
            }
        }
    }
}
