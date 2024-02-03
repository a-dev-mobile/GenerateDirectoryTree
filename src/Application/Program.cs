class Program
{
    static void Main(string[] args)
    {
        // Parse command-line arguments
        var arguments = ArgumentParser.Parse(args);
        // Validate arguments and display an error message if invalid
        if (!arguments.IsValid(out var validationMessage))
        {
            Console.WriteLine($"Error: {validationMessage}");
            return;
        }

        // Extract and prepare exclusion items for directory scanning
        var excludeItems = (arguments.Arguments.GetValueOrDefault("exclude", "") ?? "")
            .Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        // Initialize the directory scanner with the root directory and exclusion items
        var scanner = new DirectoryScanner(arguments.ScanDir, excludeItems);
        // Perform the directory scan and print the directory tree
        scanner.ScanAndPrintDirectoryTree();

        // If the --showContents flag is set, print the contents of the files
        if (arguments.ShowContents)
        {
            var printer = new FileContentPrinter(scanner.FilePathsToDisplay, arguments.ScanDir);
            printer.PrintFilesContent();
        }
    }
}
