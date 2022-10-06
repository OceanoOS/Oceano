using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.IO;

namespace Oceano.Commands
{
    public class fs
    {

        public static CosmosVFS cosmosVFS = new();
        public static void Init(CosmosVFS filesystem)
        {
            VFSManager.RegisterVFS(filesystem);
        }
        public static void info(string drive, CosmosVFS filesystem)
        {
            Console.WriteLine("===== Information for " + drive + "=====");
            Console.WriteLine();
            var available_space = filesystem.GetAvailableFreeSpace(drive);
            Console.WriteLine("Available Free Space: " + available_space);
            var full_space = filesystem.GetTotalSize(drive);
            Console.WriteLine("Total Size: " + full_space);
            var fs_type = filesystem.GetFileSystemType(drive);
            Console.WriteLine("File System Type: " + fs_type);
        }
        public static void create()
        {
            Console.WriteLine("File name: ");
            var filename = Console.ReadLine();
            try
            {

                System.IO.File.Create(filename);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File created successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error creating file.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void write()
        {
            Console.WriteLine("File name: ");
            var filename = Console.ReadLine();
            Console.WriteLine("Text to write: ");
            var text = Console.ReadLine();
            try
            {
                System.IO.File.WriteAllText(filename, text);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Text writed successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error writing text.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void delete()
        {
            Console.WriteLine("File name: ");
            var filename = Console.ReadLine();
            try
            {
                System.IO.File.Delete(filename);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("File deleted successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error deleting file.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public static void mkdir()
        {
            try
            {
                Console.Write("Folder name: ");
                var dir = Console.ReadLine();
                Directory.CreateDirectory(dir);
                Console.WriteLine("Folder created successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error creating folder.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void deldir()
        {
            try
            {
                Console.Write("Folder name: ");
                var dir = Console.ReadLine();
                Directory.Delete(dir);
                Console.WriteLine("Folder deleted successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error creating folder.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
