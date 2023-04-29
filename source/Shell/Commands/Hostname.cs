using System;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Shell.Commands
{
    public class Hostname : Command
    {
        public Hostname(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            if (Kernel.FilesystemEnabled)
            {
                try
                {
                    Kernel.Host = args[0];
                    if (File.Exists(@"0:\hostname.cfg"))
                    {
                        File.WriteAllText(@"0:\hostname.cfg", args[0]);
                    }
                    else
                    {
                        File.Create(@"0:\hostname.cfg");
                        File.WriteAllText(@"0:\hostname.cfg", args[0]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return "";
        }
    }
}
