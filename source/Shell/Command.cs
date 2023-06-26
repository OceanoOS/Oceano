namespace Oceano.Shell
{
    public class Command
    {
        public readonly string name, description;
        public Command(string name, string description) { this.name = name; this.description = description; } 
        public virtual string Execute(string[] args)
        {
            return "";
        }

    }
}
