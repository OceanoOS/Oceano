using Cosmos.System.Graphics;
using Oceano.Gui.Drivers;
using Oceano.Gui.Drivers.SVGAII;
using System.Drawing;

namespace Oceano.Gui
{
    /// <summary>
    /// Graphics class, used to initialized the graphics and draw pixels in the screen. See <see cref="Graphics"/>
    /// </summary>
    public class Graphics
    {
        /// <summary>
        /// Default Cosmos canvas. See <see cref="Canvas"/>
        /// </summary>
        public Canvas canvas;
        /// <summary>
        /// SVGAII Driver. See <see cref="VMWareSVGAII"/>
        /// </summary>
        public VMWareSVGAII vMWareSVGAII;
        /// <summary>
        /// VBE Driver, using PrismGraphics. See <see cref="PrismGraphics.Extentions.VBECanvas"/>
        /// </summary>
        public PrismGraphics.Extentions.VBECanvas vbeCanvas;
        /// <summary>
        /// Mode used on screen. It can be "Auto", "VBE" or "SVGAII"
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
        /// Initialize the graphics, using specified mode. There are 3 modes: "SVGAII", "VBE" and "Auto". See <see cref="Init(string, int, int)"/>
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
                    this.screenWidth = vbeCanvas.Width;
                    this.screenHeight = vbeCanvas.Height;
                    break;
                case "Auto":
                    canvas = FullScreenCanvas.GetFullScreenCanvas(new(screenWidth, screenHeight, ColorDepth.ColorDepth32));
                    this.screenWidth = canvas.Mode.Width;
                    this.screenHeight = canvas.Mode.Height;
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
        /// Initialize the graphics using the driver preferred mode (resolution and color depth. See <see cref="InitWithDrivers"/> and <see cref="Compatibility"/>
        /// </summary>
        public void InitWithDrivers()
        {
            if (Compatibility.SVGAIISupported)
            {
                vMWareSVGAII = new();
                vMWareSVGAII.SetMode(640, 480);
                vMWareSVGAII = new();
                vMWareSVGAII.SetMode((uint)screenWidth, (uint)screenHeight);
                this.screenWidth = 640;
                this.screenHeight = 480;
            }
            else
            {
                if (Compatibility.VBESupported)
                {
                    vbeCanvas = new();
                    this.screenWidth = vbeCanvas.Width;
                    this.screenHeight = vbeCanvas.Height;
                }
                else
                {
                    canvas = FullScreenCanvas.GetFullScreenCanvas();
                    this.screenWidth = canvas.Mode.Width;
                    this.screenHeight = canvas.Mode.Height;
                }
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
                    vMWareSVGAII.DoubleBufferUpdate();
                    break;
                case "VBE":
                    vbeCanvas.Update();
                    break;
                case "Auto":
                    canvas.Display();
                    break;
            }
        }
        /// <summary>
        /// Clear the screen.
        /// </summary>
        public void Clear(Color color, PrismGraphics.Color vbeColor = new())
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.Clear((uint)color.ToArgb());
                    break;
                case "VBE":
                    vbeCanvas.Clear(vbeColor);
                    break;
                case "Auto":
                    canvas.Clear(color);
                    break;
            }
        }
        /// <summary>
        /// Draw a point on the screen.
        /// </summary>
        public void SetPixel(int x, int y, Color color, PrismGraphics.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.SetPixel((uint)x, (uint)y, (uint)color.ToArgb());
                    break;
                case "VBE":
                    vbeCanvas[x, y] = vbeColor;
                    break;
                case "Auto":
                    canvas.DrawPoint(color, x, y);
                    break;
            }
        }
        /// <summary>
        /// Draw a rectangle on the screen.
        /// </summary>
        public void DrawRectangle(int x, int y, int w, int h, Color color, PrismGraphics.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DrawRectangle((uint)color.ToArgb(), x, y, w, h);
                    break;
                case "VBE":
                    vbeCanvas.DrawRectangle(x, y, (ushort)w, (ushort)h, 0, vbeColor);
                    break;
                case "Auto":
                    canvas.DrawRectangle(color, x, y, w, h);
                    break;
            }
        }
        /// <summary>
        /// Draw a filled rectangle.
        /// </summary>
        public void DrawFillRectangle(int x, int y, int w, int h, Color color, PrismGraphics.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DrawFillRectangle((uint)x, (uint)y, (uint)w, (uint)h, (uint)color.ToArgb());
                    break;
                case "VBE":
                    vbeCanvas.DrawFilledRectangle(x, y, (ushort)w, (ushort)h, 0, vbeColor);
                    break;
                case "Auto":
                    canvas.DrawFilledRectangle(color, x, y, w, h);
                    break;
            }
        }
        /// <summary>
        /// Draw a line.
        /// </summary>
        public void DrawLine(int x, int y, int x1, int y1, Color color, PrismGraphics.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DrawLine((uint)color.ToArgb(), x, y, x1, y1);
                    break;
                case "VBE":
                    vbeCanvas.DrawLine(x, y, x1, y1, vbeColor);
                    break;
                case "Auto":
                    canvas.DrawLine(color, x, y, x1, y1);
                    break;
            }
        }
        /// <summary>
        /// Draw a bitmap, or, in VBE also a PNG Image.
        /// </summary>
        public void DrawImage(int x, int y, Image image, PrismGraphics.Image vbeImage)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DrawImage(image, (uint)x, (uint)y);
                    break;
                case "VBE":
                    vbeCanvas.DrawImage(x, y, vbeImage, false);
                    break;
                case "Auto":
                    canvas.DrawImage(image, x, y);
                    break;
            }
        }
        /// <summary>
        /// Draw a string (ASCII). See <see cref="ASC16"/>
        /// </summary>
        public void DrawString(string s, int x, int y, Color color, PrismGraphics.Color vbeColor)
        {
            switch (Mode)
            {
                case "SVGAII":
                    vMWareSVGAII.DrawStringSVGA(s, (uint)color.ToArgb(), (uint)x, (uint)y);
                    break;
                case "VBE":
                    vbeCanvas.DrawStringVBE(vbeColor, s, x, y);
                    break;
                case "Auto":
                    canvas.DrawStringVGA(color, s, x, y);
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
                case "Auto":
                    canvas.Mode = new(width, height, ColorDepth.ColorDepth32);
                    break;
            }
        }
    }
}