using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.System.Graphics.Fonts;
using Oceano.Services;
using Cosmos.System.FileSystem.VFS;

namespace Oceano.Core
{
    public static class BootManager
    {
        public static Task shellprocess = new("shproc", "Used to make shell working", Priority.High, Shell.Update, true);
        public static void Boot()
        {
            CustomConsole.PrintInfo("Initializing Console...");
            try
            {
                VGAScreen.SetFont(PCScreenFont.Default.CreateVGAFont(), PCScreenFont.Default.Height);
                TaskManager.RegisterTask(shellprocess);
                CustomConsole.PrintSuccess("Initialized Shell and Console.");
            }
            catch(Exception ex)
            {
                ErrorScreen("Error while starting console: " + ex.Message);
            }
            CustomConsole.PrintInfo("Initializing Filesystem...");
            try
            {
                Program.fs = new();
                VFSManager.RegisterVFS(Program.fs);
                CustomConsole.PrintSuccess("Filesystem initialized successfully.");
            }
            catch
            {
                CustomConsole.PrintWarning("Filesystem is disabled.");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Welcome to Oceano");
            Console.ResetColor();
        }
        public static void ErrorScreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine("Press any key to reboot");
            Console.ReadKey();
            Cosmos.System.Power.Reboot();
        }
    }
}
