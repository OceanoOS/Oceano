using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Oceano.Commands
{
    public class Filesystem
    {
        public static CosmosVFS fs = new CosmosVFS();
        public static void Init(CosmosVFS filesystem)
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(filesystem);
        }
        public static void WriteInformation(String drive, CosmosVFS filesystem)
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
        public static void CreateFile(String path)
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
        public static void WriteToFile(String path, String text)
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
        public static void DeleteFile(String path)
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
