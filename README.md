# Directory Tree Generator with File Contents

This enhanced console application, written in C#, not only generates a tree-like structure of directories and files for a specified path but also optionally displays the contents of the files. It's an invaluable tool for documenting project structures, reviewing code bases, or quickly getting an overview of a directory's contents along with file details. Additionally, the detailed output, especially with the `--showContents` flag, is particularly useful for feeding structured data into neural networks, aiding in tasks such as code analysis, pattern recognition, and automated documentation.

## Features

- **Customizable Scan Directory**: Set the root directory for the tree generation.
- **Exclusion List**: Exclude specific directories or files from the scan to tailor the output to your needs.
- **Tree-like Visualization**: Outputs the directory and file structure in a clear, tree-like format for easy understanding.
- **Optional File Contents Display**: With the `--showContents` flag, the application can also display the contents of each file listed in the structure, making it a powerful tool for in-depth directory analysis.

## Requirements

- .NET 5.0 or higher.

## Installation

1. Clone the repository to your local machine:

    ``` bash
    git clone https://github.com/a-dev-mobile/GenerateDirectoryTree.git
    ```

2. Navigate to the cloned repository.

3. Build the application:

``` bash
    dotnet build
```

## Usage

To run the application, use the following command in the terminal, replacing `[options]` with your desired command-line arguments:

``` bash
dotnet run --project /path/to/YourProject.csproj [options]
```

### Command-Line Arguments

- `--scanDir "path"`: Specify the root directory for generating the tree. This argument is mandatory.
- `--exclude "dir1 | dir2 | file1 | file2"`: A pipe-separated list of directories and files to exclude from the scan. For example, `--exclude ".vs | .git | bin | obj"`.

### Example

``` bash
dotnet run --project /path/to/YourProject.csproj --scanDir "C:\Projects\MyProject" --exclude ".vs | .git | bin | obj" --showContents
```

This command will generate a tree for "C:\Projects\MyProject", excluding the ".vs", ".git", "bin", and "obj" directories and files, and display the contents of the included files.

## Output Format

The application outputs the directory and file structure in a clear, tree-like format. When the `--showContents` flag is used, it additionally displays the contents of each file listed in the structure after the tree.

- **Without** `--showContents` **flag**: Only the tree structure is displayed, showing directories and files without their contents.
- **With** `--showContents` **flag**: After the tree structure, the contents of each file are displayed under their respective paths, enhancing the tree with detailed file information.

### Example Without `--showContents`

```bash
MyProject/
├── src/
│   ├── file1.cs
│   └── file2.cs
└── test/
    └── testfile1.cs

```

### Example Wit `--showContents`

```bash
MyProject/
├── src/
│   ├── file1.cs
│   └── file2.cs
└── test/
    └── testfile1.cs

--- File Contents ---
src/file1.cs:
// Contents of file1.cs
namespace ExampleNamespace
{
    class ExampleClass
    {
        static void Main(string[] args)
        {
            // Example code
        }
    }
}

src/file2.cs:
// Contents of file2.cs
namespace ExampleNamespace
{
    class AnotherClass
    {
        void ExampleMethod()
        {
            // Example code
        }
    }
}

test/testfile1.cs:
// Contents of testfile1.cs
using Xunit;
public class TestClass
{
    [Fact]
    public void TestMethod()
    {
        // Test code
    }
}


```

## Contributing

Contributions are welcome! Please feel free to submit a pull request or create an issue for any bugs, features, or improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
