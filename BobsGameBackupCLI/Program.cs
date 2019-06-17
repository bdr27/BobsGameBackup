using BobsGameBackupLIB;
using System;

namespace BobsGameBackupCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Source: ");
            var source = Console.ReadLine();
            Console.WriteLine("Destination: ");
            var destination = Console.ReadLine();
            while(!string.IsNullOrEmpty(source.Trim()) && !string.IsNullOrEmpty(destination.Trim()))
            {
                LinkCreator.LinkDirectory(source, destination);

                Console.WriteLine("Source: ");
                source = Console.ReadLine();
                Console.WriteLine("Destination: ");
                destination = Console.ReadLine();
            }
        }
    }
}
