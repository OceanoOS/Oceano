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
        [ManifestResourceStream(ResourceName = "Oceano.Resources.desktop.bmp")]
        public static byte[] desktop;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.menu.bmp")]
        public static byte[] menu;
    }
}
