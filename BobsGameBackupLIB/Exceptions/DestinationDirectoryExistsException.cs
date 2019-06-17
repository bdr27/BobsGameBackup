using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class DestinationDirectoryExistsException : Exception
    {
        private string destinationDirectory;
        public DestinationDirectoryExistsException(string destinationDirectory) : base($"Directory already exists {destinationDirectory}")
        {
            this.destinationDirectory = destinationDirectory;
        }
    }
}
