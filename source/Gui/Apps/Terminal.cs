using Cosmos.System;
using Cosmos.System.Graphics;
using Oceano.Commands;
using PrismGraphics;
using System;
namespace Oceano.Gui.Apps
{
    public class Terminal : App
    {
        public string terminaltext, command, response;
        readonly int textEachLine;
        readonly int textTotal;
        public CommandManager commandManager = new();
        KeyEvent keyEvent;
        public Terminal(bool visible, int w, int h, int x = 0, int y = 0) : base("Terminal", visible, w, h, x, y)
        {
            textEachLine = width / 9;
            textTotal = height / 20;
            Write(">");
        }
        public override void _Update()
        {
            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Enter:
                        response = commandManager.ProcessInput(command);
                        terminaltext += "\n";
                        terminaltext += response;
                        command = "";
                        WriteLine(">");
                        break;
                    case ConsoleKeyEx.Backspace:
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
            Graphics.Canvas.DrawString(x, y, s, Font.Fallback, Color.White);
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
                    case ConsoleKeyEx.Enter:  break;
                }
            }
            return Input;
        }
    }
}
