using System;

namespace FileHelper.Core
{
    public class InvalidFileException : Exception
    {
        public InvalidFileException()
        {
        }

        public InvalidFileException(string message) : base(message)
        {
        }

        public InvalidFileException(string message, Exception e) : base(message, e)
        {
        }
    }
}