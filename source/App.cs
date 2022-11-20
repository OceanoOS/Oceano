using System.Drawing;
using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;

namespace Oceano
{
    public class App
    {
        public readonly int _width;
        public readonly int _height;
        public readonly int width;
        public readonly int height;

        public int dockX;
        public int dockY;
        public int dockWidth = 40;
        public int dockHeight = 30;

        public int _x;
        public int _y;
        public int x;
        public int y;
        public string name;

        bool pressed;
        public bool visible = false;

        public int _i = 0;
        public Bitmap icon;

        public App(int width, int height, int x = 0, int y = 0)
        {
            this._width = width;
            this._height = height;
            this._x = x;
            this._y = y;

            this.x = x + 2;
            this.y = y + 22;
            this.width = width - 4;
            this.height = height - 22 - 1;
        }

        public void Update()
        {
            if (_i != 0)
            {
                _i--;
            }

            if (MouseManager.X > dockX && MouseManager.X < dockX + dockWidth && MouseManager.Y > dockY && MouseManager.Y < dockY + dockHeight)
            {
                Kernel.canvas.DrawString(name, PCScreenFont.Default, new Pen(Color.White), dockX - ((name.Length * 8) / 2) + dockWidth / 2, dockY - 20);
            }

            if (MouseManager.MouseState == MouseState.Left && _i == 0)
            {
                if (MouseManager.X > dockX && MouseManager.X < dockX + dockWidth && MouseManager.Y > dockY && MouseManager.Y < dockY + dockHeight)
                {
                    visible = !visible;
                    _i = 60;
                }
            }

            if (Kernel.Pressed)
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

                this.x = (int)MouseManager.X + 2;
                this.y = (int)MouseManager.Y + 22;
            }
            Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32,32,32)), _x, _y, _width, _height);
            Kernel.canvas.DrawRectangle(new(Kernel.avgCol), _x, _y, _width, _height);

            Kernel.canvas.DrawString(name, PCScreenFont.Default, new(Color.White), _x + 2, _y + 2);

            _Update();
        end:;
        }

        public virtual void _Update()
        {
        }
    }
}