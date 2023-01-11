using Oceano.Gui;

namespace Oceano.Commands
{
    public class Clear : Command
    {
        public Clear(string name) : base(name) { }
        public override string Execute(string[] args)
        {
            AppManager.terminal.Clear();
            return "";
        }
    }
}
