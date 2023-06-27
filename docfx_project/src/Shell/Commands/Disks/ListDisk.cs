namespace Oceano.Shell.Commands.Disks
{
    public class ListDisk : Command
    {
        public ListDisk(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            foreach (var disk in Core.Program.fs.Disks)
            {
                disk.DisplayInformation();
            }
            return "";
        }
    }
}
