using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Display = Oceano.Drivers.Display;

namespace Oceano.Graphics
{
    
    public class FilesApp
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.file.bmp")]
        static byte[] file;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.folder.bmp")]
        static byte[] folder;
        public static int x = 40;
        public static int y = 40;
        public static int w = 700;
        public static int h = 200;
        public static string text = @"0:\\ - Files";
        public static bool Opened;
        public static string path=@"0:\";
        public static void Update()
        {
            if (Opened)
            {
                Display.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), x, y, w, h);
                Display.canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x + 1, y + 1);
                Display.canvas.DrawImage(Desktop.close, x + w - 16, y);
                Display.canvas.DrawButton("Navigate", x + 1, y + h - 18, Navigate);
                Display.canvas.DrawButton("Return to Home", x + 70, y + h - 18, Return0);
                var files_list = Directory.GetFiles(path);
                var directory_list = Directory.GetDirectories(path);
                var x1 = x + 1;
                foreach (var directory in directory_list)
                {
                    Display.canvas.DrawIcon(directory, new(folder), x1, y + 20, DoNothing);
                    x1 = x1 + 80;
                }
                foreach (var file in files_list)
                {
                    Display.canvas.DrawIcon(file, new(FilesApp.file), x1, y + 20, DoNothing);
                    x1 = x1 + 80;
                }
                if (MouseManager.X >= x & MouseManager.X <= x + 200 & MouseManager.Y >= y & MouseManager.Y <= y + 16 & MouseManager.MouseState == MouseState.Left)
                {
                    x = (int)MouseManager.X - 10;
                    y = (int)MouseManager.Y - 10;
                }
                if (MouseManager.MouseState == MouseState.Left & MouseManager.X >= x + w - 16 & MouseManager.Y >= y & MouseManager.X <= x + w & MouseManager.Y <= y + 16)
                {
                    Opened = false;
                }
            }
        }
        public static void DoNothing()
        {

        }
        public static void Navigate()
        {
            var input = System.Console.ReadLine();
            path = path + @"\"+input;
            text = path + " - Files";
        }
        public static void Return0()
        {
            path = @"0:\";
            text = path + " - Files";
        }
    }
}
