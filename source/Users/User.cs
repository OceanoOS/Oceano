using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Users
{
    public class User
    {
        readonly string name, password;
        Permission permission;
        public User(string name, string password, Permission permission)
        {
            this.name = name;
            this.password = password;
            this.permission = permission;
        }
    }
}
