using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Exceptions
{
    public class SourceFileNotFoundException : Exception
    {
        private string source;
        public SourceFileNotFoundException(string sourceFile) : base($"Unable to find source file {sourceFile}")
        {
            this.source = sourceFile;
        }
    }
}
