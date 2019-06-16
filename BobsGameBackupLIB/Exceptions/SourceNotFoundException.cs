using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class SourceNotFoundException : Exception
    {
        private string source;
        public SourceNotFoundException(string sourceFile) : base($"Unable to find source file {sourceFile}")
        {
            this.source = sourceFile;
        }
    }
}
