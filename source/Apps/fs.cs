using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Oceano.Apps
{
    public class fs
    {

        public static CosmosVFS cosmosVFS = new();
        public static void init(CosmosVFS filesystem)
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
        public static void create(string path)
        {
            try
            {
                System.IO.File.Create(path);
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
        public static void write(string path, string text)
        {
            try
            {
                System.IO.File.WriteAllText(path, text);
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
        public static void delete(string path)
        {
            try
            {
                System.IO.File.Delete(path);
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
    }
}
