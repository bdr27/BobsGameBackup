using System;
using System.Collections.Generic;
using System.Text;

namespace BobsGameBackupLIB.Setup
{
    public class GameSettings
    {
        public string GameName { get; set; }
        public string Directory { get; set; }
        public List<string> Files { get; set; }
        public int SettingType { get; set; }
    }
}
