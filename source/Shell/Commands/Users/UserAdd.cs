using Oceano.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Shell.Commands.Users
{
    public class UserAdd : Command
    {
        public UserAdd(string name, string description) : base(name , description) { }
        public override string Execute(string[] args)
        {
            LoginSystem.Setup();
            return "";
        }
    }
}
