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
                Display.vMWareSVGAII.DrawIcon(x1, y + 2, new Bitmap(Files.file), file, DoNothing);
                x1 = x1 + 60;
            }
        }
        public static void DoNothing()
        {

        }
    }
}
