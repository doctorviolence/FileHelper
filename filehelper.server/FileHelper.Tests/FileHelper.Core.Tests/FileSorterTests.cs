using FileHelper.Core;
using Xunit;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using System.Xml.Linq;

namespace FileHelper.Tests.FileHelper.Core.Tests
{
    public class FileSorterTests
    {
        [Fact]
        public void ValidateFile_NoFileSelected_InvalidFileException()
        {
            var sorter = new FileSorter(new MockFileSystem());
            try
            {
                string input = "";
                sorter.ValidateFile(input);
            }
            catch (InvalidFileException e)
            {
                Assert.Equal("Please select a file", e.Message);
            }
        }

        [Fact]
        public void ValidateFile_FileDoesNotExist_InvalidFileException()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            var sorter = new FileSorter(fileSystem);
            try
            {
                string input = "/test/file.txt";
                sorter.ValidateFile(input);
            }
            catch (InvalidFileException e)
            {
                Assert.Equal("File not found", e.Message);
            }
        }

        [Fact]
        public void ValidateFile_FileIsNotXml_InvalidFileException()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            fileSystem.AddFile(@"/test/file.txt", new MockFileData("Test"));
            var sorter = new FileSorter(fileSystem);
            try
            {
                string input = "/test/file.txt";
                sorter.ValidateFile(input);
            }
            catch (InvalidFileException e)
            {
                Assert.Equal("Invalid file", e.Message);
            }
        }

        [Fact]
        public void ValidateFile_FileIsValid_ReturnTrue()
        {
            var fileSystem = new MockFileSystem();
            fileSystem.AddDirectory(@"/test/");
            fileSystem.AddFile(@"/test/file.xml", new MockFileData("Test"));
            var sorter = new FileSorter(fileSystem);

            string input = "/test/file.xml";
            bool output = sorter.ValidateFile(input);

            Assert.True(output);
        }

        [Fact]
        public void SortOrdersByDate_UnsortedXmlFile_ReturnOrderedByDate()
        {
            string xml = @"<?xml version=""1.0""?>  
                <Root>  
                    <Orders>
                        <Order><OrderDate>1997-02-12T00:00:00</OrderDate></Order>
                        <Order><OrderDate>1978-02-12T00:00:00</OrderDate></Order>
                        <Order><OrderDate>2018-02-12T00:00:00</OrderDate></Order>
                    </Orders>  
                </Root>";

            XDocument doc = XDocument.Parse(xml);
            var sorter = new FileSorter();

            XElement[] input = doc.Descendants("Orders").ToArray();
            var output = sorter.SortOrdersByDate(input);

            Assert.Equal("<Order>\n  <OrderDate>1978-02-12T00:00:00</OrderDate>\n</Order>", output[0].ToString());
            Assert.Equal("<Order>\n  <OrderDate>1997-02-12T00:00:00</OrderDate>\n</Order>", output[1].ToString());
            Assert.Equal("<Order>\n  <OrderDate>2018-02-12T00:00:00</OrderDate>\n</Order>", output[2].ToString());
        }

        //[Fact]
        //public void SortXmlDocument_AssignmentXml_ReturnOrderedByDate()
        //{
        //    var input = "/Users/joakimlindvall/Desktop/uppgift/CustomerOrders.xml";
        //
        //    var sorter = new FileSorter();
        //
        //    sorter.SortXmlDocument(input);
        //}
    }
}