using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;
using System;

namespace Oceano.Shell.Commands.Disks
{
    public class Format : Command
    {
        public Format(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            Disk SelectedDisk = Core.Program.fs.Disks[0];
            SelectedDisk.Clear();
            SelectedDisk.CreatePartition(512);
            SelectedDisk.FormatPartition(0, "FAT32", true);
            return "";
        }
    }
}
