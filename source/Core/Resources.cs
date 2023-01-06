using IL2CPU.API.Attribs;

namespace Oceano.Core
{
    public class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.boot.bmp")]
        public static byte[] boot;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        public static byte[] wallpaper;
    }
}
