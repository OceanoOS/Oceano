using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class dir
    {
        public static void Init()
        {
            Console.Write(@"Folder name: ");
            var input=Console.ReadLine();
            var directoryList = Cosmos.System.FileSystem.VFS.VFSManager.GetDirectoryListing(input);
        }
    }
}
