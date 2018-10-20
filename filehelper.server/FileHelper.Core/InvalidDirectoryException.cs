using System;

namespace FileHelper.Core
{
    public class InvalidDirectoryException : Exception
    {
        public InvalidDirectoryException()
        {
        }

        public InvalidDirectoryException(string message) : base(message)
        {
        }

        public InvalidDirectoryException(string message, Exception e) : base(message, e)
        {
        }
    }
}