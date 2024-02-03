# Changelog

## [0.0.3] - 2024-02-04

- Added `--showContents` flag to optionally display the contents of files listed in the directory tree structure. This feature not only enhances the tree visualization by providing in-depth details of file contents but also makes it convenient for feeding the structured data into neural networks. This can aid in the automated analysis of the project structure and contents, allowing neural networks to gain insights into the codebase, which is particularly useful for tasks such as code summarization, bug detection, or automated code review.

## [0.0.2] - 2024-02-03

- Changed the separator to `" | "` in the `--exclude` argument for improved clarity and consistency in specifying multiple exclusion patterns.

## [0.0.1] - 2024-02-02

- Initial release. Introduced the core functionality to generate a tree-like structure of directories and files for a specified path, with customizable scan directory and exclusion list features.
