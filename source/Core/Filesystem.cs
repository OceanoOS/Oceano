using Cosmos.Core;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace Oceano.Core
{
    public class Filesystem
    {
        public static CosmosVFS fs = new();
        public static void Init()
        {
            GCImplementation.Init();
            VFSManager.RegisterVFS(fs);
        }
    }
}