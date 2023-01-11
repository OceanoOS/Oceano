using IL2CPU.API.Attribs;

namespace Oceano.Core
{
    public class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.boot.bmp")]
        public static byte[] boot;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        public static byte[] wallpaper;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.settings.bmp")]
        public static byte[] settings;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.terminal.bmp")]
        public static byte[] terminal;
    }
}
