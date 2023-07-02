using Oceano.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using Kernel = Oceano.Core.Program;

namespace Oceano.Users
{
    class LoginSystem
    {
        public static void Login()
        {
            Dictionary<string, string> users = new();

            if (Directory.Exists(@"0:\Users\"))
            {
                var dir_list = Directory.GetDirectories(@"0:\Users\");
                foreach (var dir in dir_list)
                {
                    if (File.Exists(@"0:\Users\" + dir + @"\password.cfg"))
                        users.Add(dir.ToString(), File.ReadAllText(@"0:\Users\" + dir + @"\password.cfg"));
                }
            }
            else
            {
                users.Add("root", "password");
            }

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = "";
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine();
                Console.WriteLine("Login successful!");
                Kernel.Username = username;
                Kernel.LoggedIn = true;
                if (File.Exists("0:\\login.sh"))
                {
                    ShellLanguage.Execute("0:\\login.sh");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid username or password.");
            }
        }
        public static void Setup()
        {
            Console.WriteLine();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            try
            {
                if (Directory.Exists(@"0:\Users\")) { }
                else
                {
                    Kernel.fs.CreateDirectory(@"0:\Users\");
                }
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + "\\");
                Kernel.fs.CreateFile(@"0:\Users\" + username + @"\password.cfg");
                File.WriteAllText(@"0:\Users\" + username + @"\password.cfg", password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void Remove()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Warning: if you remove the only user in disk 0:\\, you will not be able to use this os if you reboot. Please pay attention.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Username: ");
            var username = Console.ReadLine();
            try
            {
                Directory.Delete(@"0:\Users\" + username);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void CreateHome()
        {
            Console.WriteLine();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            try
            {
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\");
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\Documents\");
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\Images\");
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\Scripts\");
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\Desktop\");
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\Music\");
                Kernel.fs.CreateDirectory(@"0:\Users\" + username + @"\home\Downloads\");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}