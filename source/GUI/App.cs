using Cosmos.System;
using PrismGraphics;
using PrismGraphics.Fonts;
using Kernel = Oceano.Core.Program;
using System;

namespace Oceano.GUI
{
    public class App
    {
        public readonly ushort _width;
        public readonly ushort _height;
        public readonly ushort width;
        public readonly ushort height;

        public int _x;
        public int _y;
        public int x;
        public int y;
        public string name;

        bool pressed;
        public bool visible = false;

        public Image icon;

        public int _i = 0;

        public App(string name, bool visible, Image icon, ushort width, ushort height, int x = 0, int y = 0)
        {
            this._width = width;
            this._height = height;
            this._x = x;
            this._y = y;

            this.x = x + 2;
            this.y = y + 22;
            this.width = Convert.ToUInt16(width - 4);
            this.height = Convert.ToUInt16(height - 22 - 1);
            
            this.name = name;
            this.visible = visible;
            this.icon = icon;
        }

        public void Update()
        {
            if (_i != 0)
            {
                _i--;
            }

            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X > _x && MouseManager.X < _x + 22 && MouseManager.Y > _y && MouseManager.Y < _y + 22)
                {
                    this.pressed = true;
                }
            }
            else
            {
                this.pressed = false;
            }

            if (!visible)
                goto end;

            if (this.pressed)
            {
                this._x = (int)MouseManager.X;
                this._y = (int)MouseManager.Y;

                this.x = _x + 2;
                this.y = _y + 22;
            }
            Kernel.Canvas.DrawFilledRectangle(_x, _y, _width, _height, 0, Color.GetPacked(255,32,32,32));
            Kernel.Canvas.DrawRectangle(_x, _y, _width, _height, 0, Color.GoogleBlue);
            Kernel.Canvas.DrawString(_x + 2, _y, name, Font.Fallback, Color.White);
            Run();

        end:;
        }

        public virtual void Run()
        {
        }
    }
}