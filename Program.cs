

class Program
{
    // Main entry point of the program
    static void Main(string[] args)
    {
        // Parse command line arguments into a dictionary
        var arguments = ParseArguments(args);

        // Check for the mandatory 'scanDir' argument
        if (!arguments.ContainsKey("scanDir") || string.IsNullOrWhiteSpace(arguments["scanDir"]))
        {
            Console.WriteLine("Error: The '--scanDir' argument is required and must specify an existing directory.");
            return;  // Exit the program if the 'scanDir' argument is missing
        }

        // Retrieve and validate the directory path from arguments
        string scanDir = arguments["scanDir"]!;
        if (!Directory.Exists(scanDir))
        {
            Console.WriteLine($"Error: The specified scan directory '{scanDir}' does not exist.");
            return;  // Exit if the specified directory does not exist
        }

        // Separator variables
        var originalSeparator = " | "; // Original string to be replaced
        var preferredSeparator = "|";    // Preferred separator

        // Process and split the 'exclude' argument into a set of directory names to ignore
        string excludeValue = (arguments.GetValueOrDefault("exclude", "") ?? "").Replace(originalSeparator, preferredSeparator);
        var excludeDirs = new HashSet<string>(excludeValue.Split(preferredSeparator, StringSplitOptions.RemoveEmptyEntries), StringComparer.OrdinalIgnoreCase);

        // Output the name of the root directory being scanned
        Console.WriteLine($"{new DirectoryInfo(scanDir).Name}/");

        // Recursively print the directory and file structure
        PrintDirectoryTree(scanDir, "", excludeDirs);
    }

    // Recursively outputs the structure of directories and files
    static void PrintDirectoryTree(string dirPath, string indent, HashSet<string> excludeDirs)
    {
        // Get all entries in the directory that are not excluded
        var entries = new DirectoryInfo(dirPath).EnumerateFileSystemInfos().Where(e => !excludeDirs.Contains(e.Name)).ToList();

        // Iterate over each entry in the current directory
        for (int i = 0; i < entries.Count; i++)
        {
            var entry = entries[i];
            bool isLast = i == entries.Count - 1;  // Check if this entry is the last in the list
            string prefix = $"{indent}{(isLast ? "└── " : "├── ")}";  // Determine the prefix based on entry position

            // Print the entry name with the appropriate prefix
            Console.WriteLine($"{prefix}{entry.Name}");

            // If the entry is a directory, recursively print its contents
            if (entry is DirectoryInfo)
            {
                PrintDirectoryTree(entry.FullName, indent + (isLast ? "    " : "│   "), excludeDirs);
            }
        }
    }

    // Parses command line arguments into a dictionary for easy access
    static Dictionary<string, string?> ParseArguments(string[] args)
    {
        var arguments = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        string? lastKey = null;

        // Iterate over each argument to process keys and their values
        foreach (var arg in args)
        {
            if (arg.StartsWith("--"))
            {
                lastKey = arg.Substring(2);  // Extract the key name
                arguments[lastKey] = null;   // Initialize the key with a null value
            }
            else if (lastKey != null)
            {
                arguments[lastKey] = arg;  // Assign the value to the last key
                lastKey = null;            // Reset the last key
            }
        }

        return arguments;  // Return the parsed arguments
    }
}
