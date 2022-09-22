using Oceano.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Oceano.Boot
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Oceano!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Oceano support the filesystem. But if you are running in real hardware, it's more safe to disable it for security. Do you want to disable it? In doubt, choose no.");
            Console.Write("Input (y/n): ");
            var input=Console.ReadLine();
            switch (input)
            {
                case "y": Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Filesystem enabled."); Filesystem.Init(Filesystem.fs); Console.ForegroundColor = ConsoleColor.White; break;
                case "n": Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Filesystem disabled."); Console.ForegroundColor = ConsoleColor.White; break;
            }
        }

        protected override void Run()
        {
            Console.Write(">");
            var input = Console.ReadLine();
            switch (input)
            {
                case "fs info": try { Filesystem.WriteInformation(@"0:\", Filesystem.fs); } catch { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error: Filesystem disabled or inaccessible."); Console.ForegroundColor = ConsoleColor.White; } break;
                case "gui":Graphics.Screen.Init();break;
                case "fs create":
                    Console.Write("Path: ");
                    var create = Console.ReadLine();
                    Filesystem.CreateFile(create);
                    break;
                default: Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("Error: Command not found."); Console.ForegroundColor = ConsoleColor.White; break;
                case "": break;
                case "fs delete":
                    Console.Write("Path: ");
                    var delete = Console.ReadLine();
                    Filesystem.DeleteFile(delete);
                    break;
                case "fs write":
                    Console.Write("Path: ");
                    var write =Console.ReadLine();
                    Console.Write("Text: ");
                    var writetext =Console.ReadLine();
                    Filesystem.WriteToFile(write, writetext);
                    break;
            }
        }
    }
}
