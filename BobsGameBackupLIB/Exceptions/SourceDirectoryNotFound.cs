using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class SourceDirectoryNotFoundException : Exception
    {
        private string sourceDirectory;
        public SourceDirectoryNotFoundException(string sourceDirectory) : ($"Unable to find directory {sourceDirectory}")
        {
            this.sourceDirectory = sourceDirectory;
        }
    }
}
