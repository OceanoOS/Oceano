using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel =Oceano.Boot.Kernel;
namespace Oceano.Graphics
{
    public class Apps
    {
        public static int x = 10;
        public static int y = 10;
        public static string text = "Apps";
        public static bool Opened;
        public static int w = 600;
        public static int h = 300;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.info.bmp")]
        static byte[] info;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.shutdown.bmp")]
        static byte[] shutdown;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.console.bmp")]
        static byte[] console;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.settings.bmp")]
        static byte[] settings;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.folder.bmp")]
        static byte[] files;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.file.bmp")]
        static byte[] notepad;
        public static void Update()
        {
            if (Opened == true)
            {
                Kernel.canvas.DrawFilledRectangle(new(Color.FromArgb(32, 32, 32)), x, y, w, h);
                Kernel.canvas.DrawString(text, PCScreenFont.Default, new(Color.White), x + 1, y + 1);
                Kernel.canvas.DrawImage(Desktop.close, x + w - 16, y);
                Kernel.canvas.DrawIcon("SysInfo", new(info), x + 1, y + 20,OpenInfoApp);
                Kernel.canvas.DrawIcon("PowerOff", new(shutdown), x + 70, y + 20, Cosmos.System.Power.Shutdown);
                Kernel.canvas.DrawIcon("Console", new(console), x + 140, y + 20, Shell.BeforeRun);
                Kernel.canvas.DrawIcon("Settings", new(settings), x + 210, y + 20, OpenSettingsApp );
                Kernel.canvas.DrawIcon("Files", new(files), x + 280, y + 20, OpenFilesApp);
                if (MouseManager.X >= x & MouseManager.X <= x + 200 & MouseManager.Y>= y & MouseManager.Y <= y + 16 & MouseManager.MouseState == MouseState.Left)
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
        public static void OpenInfoApp()
        {
            InfoApp.Opened = true;
        }
        public static void OpenSettingsApp()
        {
            SettingsApp.Opened = true;
        }
        public static void OpenFilesApp()
        {
            FilesApp.Opened = true;
        }
    }
}
