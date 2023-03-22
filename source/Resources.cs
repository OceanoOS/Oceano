using IL2CPU.API.Attribs;

namespace Oceano
{
    public static class Resources
    {
        [ManifestResourceStream(ResourceName = "Oceano.Resources.wallpaper.bmp")]
        public static byte[] wallpaper;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.program.bmp")]
        public static byte[] program;
        [ManifestResourceStream(ResourceName = "Oceano.Resources.font.psf")]
        public static byte[] font;
    }
}
