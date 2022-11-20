using Cosmos.System.Graphics.Fonts;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Oceano
{
    public class Files : App
    {
        string path;
        int x1;
        public Files(int width, int height, int x = 0, int y = 0) : base(width, height, x, y)
        {
            name = "Files";
            icon = new(Resources.folder);
            path = @"0:\";
        }

        public override void _Update()
        {
            x1 = x + 2;
            var dir_list = Directory.GetDirectories(path);
            foreach(var dir in dir_list)
            {
                Kernel.canvas.DrawIcon(x1, y + 2, new(Resources.folder), dir, true, DoNothing);
                x1 += 50;
            }
            var files_list = Directory.GetFiles(path);
            foreach(var file in files_list)
            {
                Kernel.canvas.DrawIcon(x1, y + 2, new(Resources.file), file, true, DoNothing);
                x1 += 50;
            }
        }
        public void DoNothing()
        {

        }
    }
}
