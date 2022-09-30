using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
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

                System.IO.File.Create(Boot.Kernel.currentPath + filename);
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
                System.IO.File.WriteAllText(Boot.Kernel.currentPath + filename, text);
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
                System.IO.File.Delete(Boot.Kernel.currentPath + filename);
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
        public static void cd()
        {
            Console.Write("Move to:");
            var input = Console.ReadLine();
            if (File.Exists(input))
            {
                Boot.Kernel.currentPath = input;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Folder not found.");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public static void mkdir()
        {
            try
            {
                Console.Write("Folder name: ");
                var dir = Console.ReadLine();
                Directory.CreateDirectory(Boot.Kernel.currentPath + dir);
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
                Directory.Delete(Boot.Kernel.currentPath + dir);
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
