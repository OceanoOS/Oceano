using System.Collections.Generic;

namespace Oceano.Users
{
    public enum Permission
    {
        Everyone = 0,
        User = 1,
        Root = 2
    }
    public static class Access
    {
        public static Dictionary<string, Permission> folders = new();
        public static Dictionary<string, Permission> files = new();

    }
}
