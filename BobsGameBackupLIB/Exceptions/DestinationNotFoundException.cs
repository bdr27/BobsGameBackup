using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class DestinationNotFoundException : Exception
    {
        private string destinationFile;
        public DestinationNotFoundException(string destinationFile) : base($"Unable to find source file {destinationFile}")
        {
            this.destinationFile = destinationFile;
        }
    }
}
