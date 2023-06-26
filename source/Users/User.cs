namespace Oceano.Users
{
    public class User
    {
        public readonly string name, password;
        public readonly Permission permission;
        public User(string name, string password, Permission permission)
        {
            this.name = name;
            this.password = password;
            this.permission = permission;
        }
    }
}
