using FileHelper.Core;

namespace FileHelper.Services
{
    public class FileSorterService : IFileSorterService
    {
        FileSorter _sorter = new FileSorter();

        public void SortFile(string file)
        {
            _sorter.SortXmlDocument(file);
        }
    }
}