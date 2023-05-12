using System.Collections.Generic;
using System;
using Oceano.Shell;

namespace Oceano.Shell
{
    public static class CommandManager
    {
        #region Methods

        public static ReturnCode TryInvoke(string Name, string[] Args, out string Return)
        {
            if (Commands.Count == 0)
            {
                Return = "Command not found.";
                return ReturnCode.CommandNotFound;
            }

            for (int I = 0; I < Commands.Count; I++)
            {
                // Use .ToLower to normalize strings.
                if (Commands[I].Name.ToLower() == Name.ToLower())
                {
                    Return = Commands[I].Invoke(Args);
                    return ReturnCode.Success;
                }
            }
            Return = "Command not found.";
            return ReturnCode.CommandNotFound;
        }
        public static string Invoke(string Name, string[] Args)
        {
            TryInvoke(Name, Args, out string S);
            return S;
        }
        public static string Invoke(string[] Args)
        {
            string[] NewArgs = new string[Args.Length - 1];
            for (int I = 0; I < NewArgs.Length; I++)
            {
                NewArgs[I] = Args[I + 1];
            }

            TryInvoke(Args[0], NewArgs, out string Return);
            return Return;
        }
        public static void Initialize()
        {
            _ = new Commands.Help();

            // Log for debugging
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ OK ] ");
            Console.ResetColor();
            Console.WriteLine("Initialized WaveShell successfully.");
        }

        #endregion

        #region Fields

        internal static List<Command> Commands { get; set; } = new();

        #endregion
    }
}