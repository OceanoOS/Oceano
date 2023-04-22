using Oceano.Users;

namespace Oceano.Shell.Commands
{
    public class User : Command
    {
        public User(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            switch (args[0])
            {
                case "add":
                    LoginSystem.Setup();
                    break;
                case "remove":
                    LoginSystem.Remove();
                    break;
                case "createhome":
                    LoginSystem.CreateHome();
                    break;
            }
            return "";
        }
    }
}
