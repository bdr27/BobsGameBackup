using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BobsGameBackupLIB
{
    public static class LinkCreator
    {
        public static void LinkFile(string source, string destination)
        {
            CreateHardLink(destination, source, IntPtr.Zero);
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes
        );

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
