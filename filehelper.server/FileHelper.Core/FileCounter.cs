using System.IO.Abstractions;

namespace FileHelper.Core
{
    public class FileCounter
    {
        private readonly IFileSystem _fileSystem;

        // Initializes default System.IO
        public FileCounter() : this(filesystem: new FileSystem())
        {
        }

        // Initializes mock filesystem (used for unit tests)
        public FileCounter(IFileSystem filesystem)
        {
            _fileSystem = filesystem;
        }

        public bool ValidateDirectory(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new InvalidDirectoryException("Please select a directory");

            if (!_fileSystem.Directory.Exists(path))
                throw new InvalidDirectoryException("Invalid directory");

            return true;
        }

        public int CalculateXmlFiles(string path)
        {
            bool directoryIsValid = ValidateDirectory(path);
            int files = 0;

            if (directoryIsValid)
            {
                foreach (string file in _fileSystem.Directory.GetFiles(path, "*.xml"))
                {
                    files++;
                }

                foreach (string subdirectory in _fileSystem.Directory.GetDirectories(path))
                {
                    files += CalculateXmlFiles(subdirectory);
                }
            }

            return files;
        }
    }
}