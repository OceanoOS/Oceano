using Oceano.Gui.Drivers;
using Oceano.Gui.Drivers.SVGAII;
using System.Drawing;
using PrismGL2D.Extentions;
using Oceano.Gui.Drivers.VBE;

namespace Oceano.Gui
{
    /// <summary>
    /// Graphics class, used to initialized the graphics and draw pixels in the screen. See <see cref="Graphics"/>
    /// </summary>
    public class Graphics
    {
        /// <summary>
        /// SVGAII Driver. See <see cref="VMWareSVGAII"/>
        /// </summary>
        public VMWareSVGAII vMWareSVGAII;
        /// <summary>
        /// VBE Driver, using PrismGraphics. See <see cref="PrismGL2D.Extentions.VBECanvas"/>
        /// </summary>
        public VBECanvas vbeCanvas;
        /// <summary>
        /// Mode used on screen. It can be "VBE" or "SVGAII"
        /// </summary>
        public string Mode;
        /// <summary>
        /// Screen Width.
        /// </summary>
        public int screenWidth;
        /// <summary>
        /// Screen Height.
        /// </summary>
        public int screenHeight;

        /// <summary>
        /// Initialize the graphics, using specified mode. There are 2 modes: "SVGAII" and "VBE". See <see cref="Init(string, int, int)"/>
        /// </summary>
        public void Init(string mode, int screenWidth = 640, int screenHeight = 480)
        {
            this.Mode = mode;
            switch (mode)
            {
                default:
                    System.Console.WriteLine("Mode not supported.");
                    break;
                case "VBE":
                    vbeCanvas = new();
                    this.screenWidth = (int)vbeCanvas.Width;
                    this.screenHeight = (int)vbeCanvas.Height;
                    break;
                case "SVGAII":
                    vMWareSVGAII = new();
                    vMWareSVGAII.SetMode((uint)screenWidth, (uint)screenHeight);
                    this.screenWidth = screenWidth;
                    this.screenHeight = screenHeight;
                    break;
            }
        }
        /// <summary>
        /// Update the screen.
        /// </summary>
        public void Update()
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DoubleBuffer_Update();
                    break;
                case "VBE":
                    vbeCanvas.Update();
                    break;
            }
        }
        /// <summary>
        /// Clear the screen.
        /// </summary>
        public void Clear(Color color, PrismGL2D.Color vbeColor = new())
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.Clear((uint)color.ToArgb());
                    break;
                case "VBE":
                    vbeCanvas.Clear(vbeColor);
                    break;
            }
        }
        /// <summary>
        /// Draw a point on the screen.
        /// </summary>
        public void SetPixel(int x, int y, Color color, PrismGL2D.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.SetPixel((uint)x, (uint)y, (uint)color.ToArgb());
                    break;
                case "VBE":
                    vbeCanvas[x, y] = vbeColor;
                    break;
            }
        }
        /// <summary>
        /// Draw a rectangle on the screen.
        /// </summary>
        public void DrawRectangle(int x, int y, int w, int h, Color color, PrismGL2D.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DoubleBuffer_DrawRectangle((uint)color.ToArgb(), x, y, w, h);
                    break;
                case "VBE":
                    vbeCanvas.DrawRectangle(x, y, (ushort)w, (ushort)h, 0, vbeColor);
                    break;
            }
        }
        /// <summary>
        /// Draw a filled rectangle.
        /// </summary>
        public void DrawFillRectangle(int x, int y, int w, int h, Color color, PrismGL2D.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DoubleBuffer_DrawFillRectangle((uint)x, (uint)y, (uint)w, (uint)h, (uint)color.ToArgb());
                    break;
                case "VBE":
                    vbeCanvas.DrawFilledRectangle(x, y, (ushort)w, (ushort)h, 0, vbeColor);
                    break;
            }
        }
        /// <summary>
        /// Draw a line.
        /// </summary>
        public void DrawLine(int x, int y, int x1, int y1, Color color, PrismGL2D.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DoubleBuffer_DrawLine((uint)color.ToArgb(), x, y, x1, y1);
                    break;
                case "VBE":
                    vbeCanvas.DrawLine(x, y, x1, y1, vbeColor);
                    break;
            }
        }
        /// <summary>
        /// Draw a bitmap or, in VBE, also a PNG Image.
        /// </summary>
        public void DrawImage(int x, int y, Cosmos.System.Graphics.Image image, PrismGL2D.Image vbeImage)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DoubleBuffer_DrawImage(image, (uint)x, (uint)y);
                    break;
                case "VBE":
                    vbeCanvas.DrawImage(x, y, vbeImage, false);
                    break;
            }
        }
        /// <summary>
        /// Draw a string (ASCII). See <see cref="ASC16"/>
        /// </summary>
        public void DrawString(string s, int x, int y, Color color, PrismGL2D.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DrawACSIIString(s, (uint)color.ToArgb(), (uint)x, (uint)y);
                    break;
                case "VBE":
                    vbeCanvas.DrawACSIIString(vbeColor, s, x, y);
                    break;
            }
        }
        /// <summary>
        /// Set a graphics mode, doesn't work in VBE.
        /// </summary>
        public void SetMode(int width, int height)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.SetMode((uint)width, (uint)height);
                    break;
                case "VBE": break;
            }
        }
    }
}