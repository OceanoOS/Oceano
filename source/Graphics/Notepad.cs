﻿using Cosmos.System;
using Oceano.Graphics;
using System.Drawing;
using System.Xml.Linq;

namespace Oceano.Graphics
{
    class Notepad : App
    {
        int textEachLine;
        public string text = string.Empty;

        public Notepad(uint width, uint height, uint x = 0, uint y = 0) : base(width, height, x, y)
        {
            textEachLine = (int)width / 8;
            name = "Notepad";
        }

        public override void _Update()
        {
            KeyEvent keyEvent;
            if (KeyboardManager.TryReadKey(out keyEvent))
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

            Display.vMWareSVGAII.DoubleBuffer_DrawFillRectangle(x, y, width, height-20, (uint)Color.FromArgb(32,32,32).ToArgb());

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

                Display.vMWareSVGAII.DrawACSIIString(s, (uint)Color.White.ToArgb(), x, y);
            }
            else
            {
                Display.vMWareSVGAII.DrawACSIIString("Write here", (uint)Color.Gray.ToArgb(), x, y);
            }
        }
    }
}