using Microsoft.VisualStudio.TestTools.UnitTesting;
using BobsGameBackupLIB;
using System.IO;

namespace BobGameBackupTest
{
    [TestClass]
    public class LinkCreatorTests
    {
        /// <summary>
        /// Checks to see whether or not the link file gets created and destroyed properly
        /// and that all the content inside the linked file is correct
        /// </summary>
        [TestMethod]
        public void LinkFileTest()
        {
            string source = @"LinkFileTest\LinkFileTest_NoModification.txt";
            string destination = @"LinkFileTest\Success\LinkFileTest_NoModification.txt";
            CleanDestinationDirectory(source, destination);
            LinkCreator.LinkFile(source, destination);
            Assert.IsTrue(File.Exists(source));
            Assert.IsTrue(File.Exists(destination));
            Assert.AreEqual(ReadFileContents(source), ReadFileContents(destination));
            File.Delete(source);
            Assert.IsFalse(File.Exists(source));
            Assert.IsTrue(File.Exists(destination));
            File.Delete(destination);
            Assert.IsFalse(File.Exists(destination));
        }

        [TestMethod]
        public void LinkFileTest_Modification_Source()
        {
            string source = @"LinkFileTest\LinkFileTest_Modification_Source.txt";
            string destination = @"LinkFileTest\Success\LinkFileTest_Modification_Source.txt";
            CleanDestinationDirectory(source, destination);
            LinkCreator.LinkFile(source, destination);
            Assert.IsTrue(File.Exists(source));
            Assert.IsTrue(File.Exists(destination));
            Assert.AreEqual(ReadFileContents(source), ReadFileContents(destination));
            using (var writer = new StreamWriter(source, true))
            {
                writer.WriteLine("I really hope that this works");
            }
            Assert.AreEqual(ReadFileContents(source), ReadFileContents(destination));
            Assert.IsTrue(File.Exists(destination));
            File.Delete(destination);
            Assert.IsFalse(File.Exists(destination));
            File.Delete(source);
            Assert.IsFalse(File.Exists(source));
        }

        [TestMethod]
        public void LinkFileTest_Modification_Destination()
        {
            string source = @"LinkFileTest\LinkFileTest_Modification_Destination.txt";
            string destination = @"LinkFileTest\Success\LinkFileTest_Modification_Destination.txt";
            CleanDestinationDirectory(source, destination);
            LinkCreator.LinkFile(source, destination);
            Assert.IsTrue(File.Exists(source));
            Assert.IsTrue(File.Exists(destination));
            Assert.AreEqual(ReadFileContents(source), ReadFileContents(destination));
            using (var writer = new StreamWriter(destination, true))
            {
                writer.WriteLine("I really hope that this also works cause that'd be cool");
            }
            Assert.AreEqual(ReadFileContents(source), ReadFileContents(destination));
            Assert.IsTrue(File.Exists(destination));
            File.Delete(destination);
            Assert.IsFalse(File.Exists(destination));
            File.Delete(source);
            Assert.IsFalse(File.Exists(source));
        }

        private void CleanDestinationDirectory(string source, string destination)
        {
            CreateDirectory(destination);
            Assert.IsTrue(File.Exists(source));
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }
            Assert.IsFalse(File.Exists(destination));
        }

        private string ReadFileContents(string path)
        {
            var result = "";
            using (var reader = new StreamReader(path))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        private void CreateDirectory(string location)
        {
            var dir = Path.GetDirectoryName(location);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}