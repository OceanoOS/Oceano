using Cosmos.System;
using System;
using System.Drawing;

namespace Oceano.Gui
{
    public class Desktop
    {
        public static string time;
        public static void Update()
        {
            int oldy = 25;
            int oldx = 2;
            foreach (var app in AppManager.apps)
            {
                int y = oldy;
                int x = oldx;
                Kernel.canvas.DrawIcon(x, y, app.name, app.icon);
                if (MouseManager.X >= x & MouseManager.X <= x + 40 & MouseManager.Y >= y & MouseManager.Y <= y + 40 & MouseManager.MouseState == MouseState.Left)
                {
                    app.visible = true;
                }
                oldy = oldy + 48;
                if (AppManager.apps.Count * 48 > Kernel.canvas.Mode.Rows)
                {
                    oldx = 60;
                    oldy = 25;
                }
                app.Update();
            }
            oldy = 25;
            oldx = 2;
            time = DateTime.Now.ToString();
            Kernel.canvas.DrawFilledRectangle(Color.FromArgb(32, 32, 32), 0, 0, Kernel.canvas.Mode.Columns, 20);
            Kernel.canvas.DrawString("Shutdown", Graphics.font, Color.White, 2, 2);
            if (MouseManager.X >= 2 & MouseManager.Y >= 2 & MouseManager.X <= 66 & MouseManager.Y <= 18 & MouseManager.MouseState == MouseState.Left)
            {
                Power.Shutdown();
            }
            Kernel.canvas.DrawString(time, Graphics.font, Color.White, Kernel.canvas.Mode.Columns - (time.Length * 8 + 2), 2);
            Kernel.canvas.DrawLine(Color.Cyan, 0, 21, Kernel.canvas.Mode.Columns, 21);
        }
    }
}