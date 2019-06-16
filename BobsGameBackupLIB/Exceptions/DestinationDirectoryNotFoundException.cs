using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class DestinationDirectoryNotFoundException : Exception
    {
        private string destinationFile;
        public DestinationDirectoryNotFoundException(string destinationFile) : base($"Unable to find source file {destinationFile}")
        {
            this.destinationFile = destinationFile;
        }
    }
}
