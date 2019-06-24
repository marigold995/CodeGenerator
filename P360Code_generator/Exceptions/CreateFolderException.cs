using System;

namespace _360Generator.Exceptions
{
    internal class CreateFolderException : Exception
    {
        public CreateFolderException()
        {
        }

        public CreateFolderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}