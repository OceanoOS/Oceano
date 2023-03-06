using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.program.bmp")]
        public static byte[] program;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        public static byte[] wallpaper;
    }
}
