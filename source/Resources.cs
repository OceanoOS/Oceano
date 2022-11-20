using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano
{
    public class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.program.bmp")]
        public static byte[] program;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.folder.bmp")]
        public static byte[] folder;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.file.bmp")]
        public static byte[] file;
    }
}
