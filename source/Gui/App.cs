using Cosmos.System;
using Cosmos.System.Graphics;

namespace Oceano.Gui
{
    public class App
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public string name;
        public bool visible;
        public Bitmap icon;
        public App(int x, int y, int w, int h, string name)
        {
            this.x = x;
            this.y = y;
            this.width = w;
            this.height = h;
            this.name = name;
        }
        public void Update()
        {
            if (visible)
            {
                Kernel.canvas.DrawRectangle(Graphics.cyan, x, y, width, height);
                Kernel.canvas.DrawFilledRectangle(Graphics.materialblack, x + 1, y + 1, width - 1, height - 1);
                Kernel.canvas.DrawString(name, Graphics.font, Graphics.white, x + 2, y + 2);
                Kernel.canvas.DrawDangerButton(x + width - 25, y + 2, "X", Close);
                if (MouseManager.MouseState == MouseState.Left)
                {
                    if (MouseManager.X >= x & MouseManager.Y >= y & MouseManager.X <= x + width & MouseManager.Y <= y + 20)
                    {
                        this.x = (int)MouseManager.X - 10;
                        this.y = (int)MouseManager.Y - 10;
                    }
                }
                _Update();
            }
        }
        public virtual void _Update()
        {

        }
        public void Close()
        {
            visible = false;
        }
    }
}