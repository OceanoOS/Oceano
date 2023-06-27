using Oceano.Users;

namespace Oceano.Shell.Commands.Users
{
    public class UserAdd : Command
    {
        public UserAdd(string name, string description) : base(name, description) { }
        public override string Execute(string[] args)
        {
            LoginSystem.Setup();
            return "";
        }
    }
}
