public class ArgumentParser
{
    public IReadOnlyDictionary<string, string?> Arguments { get; }

    private ArgumentParser(Dictionary<string, string?> arguments)
    {
        Arguments = arguments;
    }

    public static ArgumentParser Parse(string[] args)
    {
        var arguments = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        string? lastKey = null;
        foreach (var arg in args)
        {
            if (arg.StartsWith("--"))
            {
                lastKey = arg[2..];
                arguments[lastKey] = null;
            }
            else if (lastKey != null)
            {
                arguments[lastKey] = arg;
                lastKey = null;
            }
        }
        return new ArgumentParser(arguments);
    }

    public bool IsValid(out string validationMessage)
    {
        if (!Arguments.ContainsKey("scanDir") || string.IsNullOrWhiteSpace(Arguments["scanDir"]))
        {
            validationMessage = "The '--scanDir' argument is required and must specify an existing directory.";
            return false;
        }

        validationMessage = string.Empty;
        return true;
    }

    public string ScanDir => Arguments["scanDir"]!;
    public bool ShowContents => Arguments.ContainsKey("showContents");
}
