using BobsGameBackupLIB.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BobsGameBackupLIB
{
    public static class LinkCreator
    {
        /// <summary>
        /// Links two file locations together
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void LinkFile(string source, string destination)
        {
            if (!File.Exists(source))
            {
                throw new SourceNotFoundException(source);
            }
            if (File.Exists(destination))
            {
                throw new DestinationFileExistsException(destination);
            }
            if (!Directory.Exists(Path.GetDirectoryName(destination)))
            {
                throw new DestinationNotFoundException(destination);
            }

            CreateHardLink(destination, source, IntPtr.Zero);
        }

        /// <summary>
        /// To create a link between two files.
        /// This code was found on https://www.codeproject.com/Articles/70863/Hard-Links-vs-Soft-Links
        /// The author of the code is Mohammad Elsheimy
        /// </summary>
        /// <param name="lpFileName">The path of the new hard link to be created. Notice that, it should reside in the location (local disk or network share) as the source file.</param>
        /// <param name="lpExistingFileName">The path of the source file to create the hard link from.</param>
        /// <param name="lpSecurityAttributes">The security descriptor for the new file. Till now, it is reserved for future use and it should not be used.</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes
        );

        /// <summary>
        /// This code was found on https://www.codeproject.com/Articles/70863/Hard-Links-vs-Soft-Links
        /// The author of the code is Mohammad Elsheimy
        /// </summary>
        /// <param name="lpSymlinkFileName"></param>
        /// <param name="lpTargetFileName"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateSymbolicLink(
            string lpSymlinkFileName,
            string lpTargetFileName,
            uint dwFlags
        );

        const uint SYMBLOC_LINK_FLAG_FILE = 0x0;
        const uint SYMBLOC_LINK_FLAG_DIRECTORY = 0x1;
    }
}
