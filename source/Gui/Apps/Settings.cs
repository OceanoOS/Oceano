using Cosmos.System;
using PrismGraphics;

namespace Oceano.Gui.Apps
{
    public class Settings : App
    {
        public Settings(bool visible, int w, int h, int x = 0, int y = 0) : base("Settings", visible, w, h, x, y)
        {

        }
        public override void _Update()
        {
            Graphics.Canvas.DrawString(x, y, "Mouse Sensivity", Font.Fallback, Color.White);
            Graphics.Canvas.DrawRectangle(x, y + 20, 10, 16, 0, Color.GoogleBlue);
            Graphics.Canvas.DrawString(x + 3, y + 20, "1", Font.Fallback, Color.White);
            Graphics.Canvas.DrawRectangle(x + 15, y + 20, 10, 16, 0, Color.GoogleBlue);
            Graphics.Canvas.DrawString(x + 18, y + 20, "2", Font.Fallback, Color.White);
            if (MouseManager.MouseState == MouseState.Left)
            {
                if (MouseManager.X >= x & MouseManager.X <= x + 10 & MouseManager.Y >= y + 23 & MouseManager.Y <= y + 40)
                {
                    MouseManager.MouseSensitivity = 1;
                }
                if (MouseManager.X >= x + 15 & MouseManager.X <= x + 25 & MouseManager.Y >= y + 23 & MouseManager.Y <= y + 40)
                {
                    MouseManager.MouseSensitivity = 2;
                }
            }
        }
    }
}
