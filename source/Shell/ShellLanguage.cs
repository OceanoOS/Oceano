using Oceano.Core;
using System.IO;

namespace Oceano.Shell
{
    /// <summary>
    /// Shell language class, used for running commands easier.
    /// </summary>
    public class ShellLanguage
    {
        /// <summary>
        /// Execute a Shell (.sh) file.
        /// </summary>
        /// <param name="filename">Path of the file.</param>
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
