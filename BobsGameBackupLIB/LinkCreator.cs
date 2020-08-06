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
        //private const uint SYMBLOC_LINK_FLAG_FILE = 0x0;
        private const uint SYMBLOC_LINK_FLAG_DIRECTORY = 0x1;

        /// <summary>
        /// Creates a hard link between a source file (Existing) and destination file (New File)
        /// </summary>
        /// <exception cref="SourceFileNotFoundException">Source file doesn't exist</exception>
        /// <exception cref="DestinationFileExistsException">Destination file already exists</exception>
        /// <exception cref="DestinationDirectoryNotFoundException">Destination directory not found</exception>
        /// <param name="source">Source File</param>
        /// <param name="destination">Destination file location</param>
        public static void LinkFile(string source, string destination)
        {
            if (!File.Exists(source))
            {
                throw new SourceFileNotFoundException(source);
            }
            if (File.Exists(destination))
            {
                throw new DestinationFileExistsException(destination);
            }
            if (!Directory.Exists(Path.GetDirectoryName(destination)))
            {
                throw new DestinationDirectoryNotFoundException(destination);
            }

            CreateHardLink(destination, source, IntPtr.Zero);
        }

        /// <summary>
        /// For this function to work application needs to be run as administrator
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static bool LinkDirectory(string source, string destination)
        {
            if (!Directory.Exists(source))
            {
                throw new SourceDirectoryNotFoundException(source);
            }
            if (Directory.Exists(destination))
            {
                throw new DestinationDirectoryExistsException(destination);
            }
            //var files = Directory.GetFiles(source);
            //foreach(var file in files)
            //{
            //    File.Move(file, $"{destination}\\{Path.GetFileName(file)}");
            //}
            return CreateSymbolicLink(destination, source, SYMBLOC_LINK_FLAG_DIRECTORY);
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
    }
}
