using Cosmos.Core.Memory;
using Cosmos.System;
using Oceano.Shell;
using PrismGraphics;
using PrismGraphics.Fonts;

namespace Oceano.GUI.Apps
{
    public class Terminal : App
    {
        public string terminaltext, command, response;
        readonly int textEachLine;
        readonly int textTotal;
        public CommandManager commandManager = new();
        KeyEvent keyEvent;
        public Terminal() : base(400, 250, 30, 30)
        {
            name = "Terminal";
            textEachLine = width / 9;
            textTotal = height / 20;
            Write(">");
        }
        public override void Run()
        {
            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Enter:
                        Heap.Collect();
                        response = commandManager.ProcessInput(command);
                        terminaltext += "\n";
                        terminaltext += response;
                        command = "";
                        WriteLine(">");
                        break;
                    case ConsoleKeyEx.Backspace:
                        Heap.Collect();
                        command = command.Remove(command.Length - 1);
                        terminaltext = terminaltext.Remove(terminaltext.Length - 1);
                        break;
                    default:
                        command += keyEvent.KeyChar;
                        terminaltext += keyEvent.KeyChar;
                        break;
                }
            }
            string s = string.Empty;
            if (terminaltext.Length != 0)
            {
                int i = 0;
                foreach (char c in terminaltext)
                {
                    s += c;
                    i++;
                    if (i + 1 == textEachLine || c == '\n')
                    {
                        if (c != '\n')
                        {
                            s += "\n";
                        }
                        i = 0;
                    }
                }
            }
            Graphics.vMWareSVGAII.DrawString(x, y, s, Font.Fallback, Color.White);
            Heap.Collect();
        }
        public void Clear()
        {
            terminaltext = string.Empty;
        }
        public void WriteLine(string text)
        {
            terminaltext += "\n";
            terminaltext += text;
        }
        public void Write(string text)
        {
            terminaltext += text;
        }
        public string ReadLine()
        {
            string Input = string.Empty;
            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    default: Input += keyEvent.KeyChar; break;
                    case ConsoleKeyEx.Enter: break;
                }
            }
            return Input;
        }
    }
}
