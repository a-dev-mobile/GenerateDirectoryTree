# Directory Tree Generator

This console application, written in C#, generates a tree-like structure of directories and files for a specified path, allowing you to easily visualize the organization of your files. It's particularly useful for documenting project structures or quickly getting an overview of a directory's contents.

## Features

- **Customizable Scan Directory**: Set the root directory for the tree generation.
- **Exclusion List**: Exclude specific directories from the scan to tailor the output.
- **Tree-like Visualization**: Outputs the directory and file structure in a clear, tree-like format.

## Requirements

- .NET 5.0 or higher.

## Installation

1. Clone the repository to your local machine:

    ```
    git clone https://github.com/yourusername/your-repo-name.git
    ```

2. Navigate to the cloned repository.

3. Build the application:

```
    dotnet build
```

## Usage

To run the application, use the following command in the terminal, replacing `[options]` with your desired command-line arguments:

```
dotnet run --project /path/to/YourProject.csproj [options]
```

### Command-Line Arguments

- `--scanDir "path"`: Specify the root directory for generating the tree. If not provided, the current directory is used.
- `--exclude "dir1 | dir2"`: A comma-separated list of directories to exclude from the scan. For example, `--exclude "bin | obj"`.

### Example

```
dotnet run --project /path/to/YourProject.csproj --scanDir "C:\Projects\MyProject" --exclude "bin | obj | node_modules"
```

This command will generate a tree for "C:\Projects\MyProject", excluding the "bin", "obj", and "node_modules" directories.

## Output Format

The application outputs the directory structure in a tree format, with branches representing directories and leaves representing files. Empty directories are shown as branches without leaves.

```
MyProject/
├── src/
│ ├── file1.cs
│ └── file2.cs
└── test/
└── testfile1.cs
```

## Contributing

Contributions are welcome! Please feel free to submit a pull request or create an issue for any bugs, features, or improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](./LICENSE) file for details.
