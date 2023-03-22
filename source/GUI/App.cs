using Cosmos.System;
using System.Drawing;
using Kernel = Oceano.Core.Program;

namespace Oceano.GUI
{
    public class App
    {
        public readonly uint _width;
        public readonly uint _height;
        public readonly uint width;
        public readonly uint height;

        public uint dockX;
        public uint dockY;
        public uint dockWidth = 40;
        public uint dockHeight = 30;

        public uint _x;
        public uint _y;
        public uint x;
        public uint y;
        public string name;

        bool pressed;
        public bool visible = false;

        public int _i = 0;

        public App(uint width, uint height, uint x = 0, uint y = 0)
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
                Kernel.VMWareSVGAII.DrawACSIIString(name, (uint)Color.White.ToArgb(), (uint)(dockX - ((name.Length * 8) / 2) + dockWidth / 2), dockY - 20);
            }

            if (MouseManager.MouseState == MouseState.Left && _i == 0)
            {
                if (MouseManager.X > dockX && MouseManager.X < dockX + dockWidth && MouseManager.Y > dockY && MouseManager.Y < dockY + dockHeight)
                {
                    visible = !visible;
                    _i = 60;
                }
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
                this._x = MouseManager.X;
                this._y = MouseManager.Y;

                this.x = MouseManager.X + 2;
                this.y = MouseManager.Y + 22;
            }
            Kernel.VMWareSVGAII.DrawFillRectangle(_x, _y, _width, _height, (uint)Color.FromArgb(32,32,32).ToArgb());
            Kernel.VMWareSVGAII.DrawRectangle((uint)Color.Cyan.ToArgb(), _x, _y, _width, _height);
            Kernel.VMWareSVGAII.DrawACSIIString(name, (uint)Color.White.ToArgb(), _x + 2, _y + 2);
            Run();

        end:;
        }

        public virtual void Run()
        {
        }
    }
}