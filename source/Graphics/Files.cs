using Cosmos.System;
using Cosmos.System.Graphics;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class Files : App
    {
        public static string path=@"0:\";
        [ManifestResourceStream(ResourceName = "Oceano.Resources.file.bmp")]
        static byte[] file;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.folder.bmp")]
        static byte[] folder;
         string text = "";
        public Files(uint width, uint height, uint x = 0, uint y = 0) : base(width, height, x, y)
        {
            name = "Files";
        }

        public override void _Update()
        {
            uint x1 = x + 2;
            var directory_list = Directory.GetDirectories(path);
            var files_list = Directory.GetFiles(path);
            foreach(var dir in directory_list)
            {
                Display.vMWareSVGAII.DrawIcon(x1, y + 2, new Bitmap(folder), dir,DoNothing);
                x1 = x1 + 60;
            }
            foreach(var file in files_list)
            {
                Display.vMWareSVGAII.DrawIcon(x1, y + 2, new Bitmap(Files.file), file,DoNothing);
                x1 = x1 + 60;
            }
            KeyEvent keyEvent;
            if (KeyboardManager.TryReadKey(out keyEvent))
            {
                switch (keyEvent.Key)
                {
                    case ConsoleKeyEx.Enter:
                        path = text;
                        break;
                    case ConsoleKeyEx.Backspace:
                        if (text.Length != 0)
                        {
                            text = text.Remove(text.Length - 1);
                        }
                        break;
                    default:
                        text += keyEvent.KeyChar;
                        break;
                }
            }
            if(text == "")
            {
                Display.vMWareSVGAII.DrawACSIIString("Enter path", (uint)Color.Gray.ToArgb(), x + 8*6, y - 20);
            }
            else
            {
                Display.vMWareSVGAII.DrawACSIIString(text, (uint)Color.White.ToArgb(), x +8*6, y - 20);
            }
        }
        public static void DoNothing()
        {
            
        }
    }
}
