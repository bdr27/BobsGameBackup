using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class DestinationFileExistsException : Exception
    {
        private string destinationFile;
        public DestinationFileExistsException(string destinationFile) : base($"Destination file already exists {destinationFile}")
        {
            this.destinationFile = destinationFile;
        }
    }
}
