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
            Disk SelectedDisk = Core.Program.fs.Disks[Convert.ToInt16(args[0])];
            SelectedDisk.Clear();
            SelectedDisk.CreatePartition(512);
            SelectedDisk.CreatePartition((SelectedDisk.Size - 512) / 1048576);
            MBR Helper = new(SelectedDisk.Host);
            Helper.CreateMBR(SelectedDisk.Host);
            Helper.WritePartitionInformation(SelectedDisk.Partitions[0].Host, 0);
            SelectedDisk.FormatPartition(1, args[1], true);
            return "";
        }
    }
}
