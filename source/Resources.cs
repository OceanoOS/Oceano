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
        [ManifestResourceStream(ResourceName = "Oceano.Resources.font.psf")]
        public static byte[] font;
    }
}
