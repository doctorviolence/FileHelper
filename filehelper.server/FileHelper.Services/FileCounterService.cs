using FileHelper.Core;

namespace FileHelper.Services
{
    public class FileCounterService : IFileCounterService
    {
        private FileCounter _fileCounter = new FileCounter();

        public int CountXmlFiles(string dir)
        {
            return _fileCounter.CalculateXmlFiles(dir);
        }
    }
}