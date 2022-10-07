using System;

namespace Oceano.Commands
{
    public class dir
    {
        public static void Init()
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
    }
}
