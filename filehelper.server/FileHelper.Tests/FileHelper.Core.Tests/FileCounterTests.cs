using FileHelper.Core;
using Xunit;
using System.IO.Abstractions.TestingHelpers;

namespace FileHelper.Tests.FileHelper.Core.Tests
{
    public class FileCounterTests
    {
        [Fact]
        public void ValidateDirectory_InputIsEmptyOrNull_InvalidDirectoryException()
        {
            var counter = new FileCounter(new MockFileSystem());
            try
            {
                string input = "";
                counter.ValidateDirectory(input);
            }
            catch (InvalidDirectoryException e)
            {
                Assert.Equal("Please select a directory", e.Message);
            }
        }

        [Fact]
        public void ValidateDirectory_DirectoryDoesNotExist_InvalidDirectoryException()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            var counter = new FileCounter(fileSystem);
            try
            {
                string input = @"/invalid/";
                counter.ValidateDirectory(input);
            }
            catch (InvalidDirectoryException e)
            {
                Assert.Equal("Invalid directory", e.Message);
            }
        }

        [Fact]
        public void ValidateDirectory_DirectoryIsValid_ReturnTrue()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            var counter = new FileCounter(fileSystem);

            string input = @"/test/";
            bool output = counter.ValidateDirectory(input);

            Assert.True(output);
        }

        [Fact]
        public void CalculateXmlFiles_NoXmlFiles_Return0()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            fileSystem.AddFile(@"/test/file.txt", new MockFileData("Test"));
            var counter = new FileCounter(fileSystem);

            string input = @"/test/";
            int output = counter.CalculateXmlFiles(input);

            Assert.Equal(0, output);
        }

        [Fact]
        public void CalculateXmlFiles_1XmlFile_Return1()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            fileSystem.AddFile(@"/test/file.xml", new MockFileData("Test"));
            var counter = new FileCounter(fileSystem);

            string input = @"/test/";
            int output = counter.CalculateXmlFiles(input);

            Assert.Equal(1, output);
        }

        [Fact]
        public void CalculateXmlFiles_2XmlFiles_Return2()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            fileSystem.AddFile(@"/test/file.xml", new MockFileData("Test"));
            fileSystem.AddFile(@"/test/file2.xml", new MockFileData("Test"));
            var counter = new FileCounter(fileSystem);

            string input = @"/test/";

            int output = counter.CalculateXmlFiles(input);

            Assert.Equal(2, output);
        }

        [Fact]
        public void CalculateXmlFiles_SubdirectoryExists_ReturnNestedXmlFile()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            fileSystem.AddDirectory(@"/test/subdir");
            fileSystem.AddFile(@"/test/file.xml", new MockFileData("Test"));
            fileSystem.AddFile(@"/test/subdir/file2.xml", new MockFileData("Test"));
            var counter = new FileCounter(fileSystem);

            string input = @"/test/";
            int output = counter.CalculateXmlFiles(input);

            Assert.Equal(2, output);
        }
    }
}