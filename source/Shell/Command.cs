namespace Oceano.Shell
{
    public class Command
    {
        public readonly string name;
        public Command(string name) { this.name = name; }
        public virtual string Invoke(string[] args)
        {
            return "";
        }

    }
}
