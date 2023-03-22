using Cosmos.System.FileSystem.VFS;
using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Touch : Command
    {
        public Touch(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                VFSManager.CreateFile(Kernel.CurrentPath + args[0]);
                response = "File created successfully";
            }
            catch (Exception e)
            {
                response = "Error: Unable to create file. Exception: " + e.Message;
            }
            return response;
        }
    }
}
