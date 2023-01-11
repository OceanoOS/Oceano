using Cosmos.System;
using PrismGraphics;

namespace Oceano.Gui
{
    public class App
    {
        public string title;
        public bool visible, pressed;
        public int width, height, _x, _y, x, y;
        public Image icon;
        public App(string title, bool visible, int width, int height, int x = 0, int y = 0)
        {
            this._x = x;
            this._y = y;
            this.width = width;
            this.height = height;
            this.title = title;
            this.visible = visible;
            this.x = this._x + 2;
            this.y = this._y + 22;
        }
        public void Update()
        {
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
            {
                goto end;
            }
            if (this.pressed)
            {
                this._x = (int)MouseManager.X;
                this._y = (int)MouseManager.Y;

                this.x = (int)MouseManager.X + 2;
                this.y = (int)MouseManager.Y + 22;
            }
            Graphics.Canvas.DrawFilledRectangle(_x, _y, (uint)width, (uint)height, 0, Color.Black);
            Graphics.Canvas.DrawString(_x + 2, _y + 2, title, Font.Fallback, Color.White);
            Graphics.Canvas.DrawString(_x + width - 12, _y+2, "X", Font.Fallback, Color.Red);
            if (MouseManager.X >= _x + width - 10 & MouseManager.X <= _x + width & MouseManager.Y >= _y + 2 & MouseManager.Y <= _y + 20 & MouseManager.MouseState == MouseState.Left)
            {
                visible = false;
            }
            _Update();
        end:;
        }
        public virtual void _Update()
        {

        }
    }
}
