using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Xml.Linq;

namespace FileHelper.Core
{
    public class FileSorter
    {
        private readonly IFileSystem _fileSystem;

        // Initializes default System.IO
        public FileSorter() : this(filesystem: new FileSystem())
        {
        }

        // Initializes mock filesystem (used for unit tests)
        public FileSorter(IFileSystem filesystem)
        {
            _fileSystem = filesystem;
        }

        public bool ValidateFile(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new InvalidFileException("Please select a file");

            if (!_fileSystem.File.Exists(file))
                throw new InvalidFileException("File not found");

            if (!file.EndsWith(".xml"))
                throw new InvalidFileException("Invalid file");

            return true;
        }

        public void SortXmlDocument(string file)
        {
            bool fileIsValid = ValidateFile(file);

            try
            {
                if (fileIsValid)
                {
                    XDocument doc = XDocument.Load(file);

                    // Select orders elements from XML file
                    XElement[] orders = doc.Elements().Descendants("Orders").ToArray();

                    // Remove old unordered order elements from XML file
                    doc.Elements().Descendants("Orders").Remove();

                    // Retrieve new order by date elements
                    XElement[] sortedOrders = SortOrdersByDate(orders);

                    // Add new XML element OrdersByDate
                    XElement ordersByDate = new XElement("OrdersByDate");
                    ordersByDate.Add(sortedOrders);

                    // Add to XML file
                    doc.Root?.Add(ordersByDate);

                    // Save as new XML file to user's directory
                    string path = _fileSystem.Path.GetDirectoryName(file);
                    doc.Save(path + "/OrdersByDate.xml");
                }
            }
            catch (IOException e)
            {
                throw new InvalidFileException("Failed to read/open file", e);
            }
        }

        public XElement[] SortOrdersByDate(IEnumerable<XElement> elements)
        {
            var sortedItems = elements.Descendants("Order")
                .OrderBy(item => DateTime.Parse(item.Element("OrderDate")?.Value)).ToArray();

            return sortedItems;
        }
    }
}