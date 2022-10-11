using System;
using System.IO;

namespace Oceano.Commands
{
    public class Filesystem
    {
        public static void Cd()
        {
            Console.Write("Move to: ");
            var input = Console.ReadLine();
            if (Directory.Exists(input))
            {
                Boot.Kernel.path = input;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error Moving.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void Remove()
        {
            try
            {
                Console.Write("File name: ");
                var input = Console.ReadLine();
                File.Delete(Boot.Kernel.path + input);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error deleting file.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void RemoveDirectory()
        {

            try
            {
                Console.Write("File name: ");
                var input = Console.ReadLine();
                Directory.Delete(Boot.Kernel.path + input);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error deleting file.");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
        public static void DirectoryListing()
        {

            try
            {
                var directoryList = Cosmos.System.FileSystem.VFS.VFSManager.GetDirectoryListing(Boot.Kernel.path);
                foreach (var directoryEntry in directoryList)
                {
                    Console.WriteLine(directoryEntry.mName);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public static void CreateFile()
        {

            Console.Write("File name: ");
            var input = Console.ReadLine();
            try
            {
                var file_stream = File.Create(Boot.Kernel.path + input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
