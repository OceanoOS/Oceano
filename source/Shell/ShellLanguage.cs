using Oceano.Core;
using System.IO;

namespace Oceano.Shell
{
    public class ShellLanguage
    {
        public static void Execute(string filename)
        {
            if (filename.EndsWith(".sh"))
            {
                foreach (var line in File.ReadAllLines(filename))
                {
                    Core.Shell.commandManager.ProcessInput(line);
                }
            }
            else
            {
                CustomConsole.PrintError("Error while executing file: " + "Not a valid sh file!");
            }
        }
    }
}
