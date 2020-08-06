using BobsGameBackupLIB.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BobsGameBackupTest.Setup
{
    [TestClass]
    public class SettingsTests
    {
                /// <summary>
        /// Makes sure the settings file is getting loaded and parsed correctly
        /// </summary>
        [TestMethod]
        public void LoadTest()
        {
            string location = "Setting\bobsGameBackup.json";
            Assert.IsTrue(LoadSettings.LoadFile(location, out GameSettings gameSettings));
            Assert.IsNotNull(gameSettings);            
        }

        [TestMethod]
        public void SaveTest()
        {
            string location = "SaveSetting\bobsGameBackup.json";
            string directory = Path.GetDirectoryName(location);
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory);
            }
            GeneralSettings gs = new GeneralSettings
            {
                GameSettings = new List<GameSettings>()
            };
            gs.GameSettings.Add(new GameSettings
            {
                Directory = "Hello/World",
                GameName = "Hello World Simulator",
                SettingType = (int)SettingType.Directory
            });
            Assert.AreEqual(1, gs.GameSettings.Count);
        }
    }
}
