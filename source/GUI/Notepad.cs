using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Fonts;
using System;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    class Notepad : App
    {
        readonly int textEachLine;
        public string text = string.Empty;

        public Notepad() : base("Notepad", false, Image.FromBitmap(Resources.notepad), 720, 480, 20, 20)
        {
            textEachLine = (int)width / 9;
        }

        public override void Run()
        {
            if (KeyboardManager.TryReadKey(out KeyEvent keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Enter:
                        this.text += "\n";
                        break;
                    case ConsoleKeyEx.Backspace:
                        if (this.text.Length != 0)
                        {
                            this.text = this.text.Remove(this.text.Length - 1);
                        }
                        break;
                    default:
                        this.text += keyEvent.KeyChar;
                        break;
                }
            }

            Kernel.Canvas.DrawFilledRectangle(x, y + 22, width, Convert.ToUInt16(height - 22), 0, Color.White);

            if (text.Length != 0)
            {
                string s = string.Empty;
                int i = 0;
                foreach (char c in text)
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

                Kernel.Canvas.DrawString(x, y + 24, text, Font.Fallback, Color.Black);
            }
            else
            {
                Kernel.Canvas.DrawString(x, y + 24, "Edit anything you want", Font.Fallback, Color.LightGray);
            }
            Kernel.Canvas.DrawButton(x, y, "Clear", Color.Red);
            if (MouseManager.X >= x & MouseManager.X <= x + 45 & MouseManager.Y >= y & MouseManager.Y <= y + 20 & MouseManager.MouseState == MouseState.Left)
            {
                text = string.Empty;
            }
        }
    }
}