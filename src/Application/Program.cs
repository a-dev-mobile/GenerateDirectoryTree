class Program
{
    static void Main(string[] args)
    {
        var arguments = ArgumentParser.Parse(args);
        if (!arguments.IsValid(out var validationMessage))
        {
            Console.WriteLine($"Error: {validationMessage}");
            return;
        }

        var excludeItems = (arguments.Arguments.GetValueOrDefault("exclude", "") ?? "")
            .Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var scanner = new DirectoryScanner(arguments.ScanDir, excludeItems);
        scanner.ScanAndPrintDirectoryTree();

        if (arguments.ShowContents)
        {
            var printer = new FileContentPrinter(scanner.FilePathsToDisplay, arguments.ScanDir);
            printer.PrintFilesContent();
        }
    }
}
