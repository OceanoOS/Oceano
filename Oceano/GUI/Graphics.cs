using PrismGraphics;
using PrismGraphics.Extentions.VESA;
using PrismGraphics.Extentions.VMWare;
using PrismGraphics.Fonts;
using Cosmos.System;

namespace Oceano.GUI
{
    public class Graphics
    {
        public SVGAIICanvas SVGAIICanvas { get; set; }
        public VBECanvas VBECanvas { get; set; }
        public int ScreenWidth;
        public int ScreenHeight;
        public readonly string Mode;
        public Graphics(ushort w, ushort h, string Mode = "")
        {
            this.Mode = Mode;

        }
        public void Init(bool Mouse = true)
        {
            switch (Mode)
            {
                default: SVGAIICanvas = new((ushort)ScreenWidth, (ushort)ScreenHeight); break;
                case "SVGAII": SVGAIICanvas = new((ushort)ScreenWidth, (ushort)ScreenHeight); break;
                case "VBE": VBECanvas = new(); break;
            }
            if (Mouse)
            {
                MouseManager.ScreenWidth = (uint)ScreenWidth;
                MouseManager.ScreenHeight = (uint)ScreenHeight;
                MouseManager.X = (uint)ScreenWidth / 2;
                MouseManager.Y = (uint)ScreenHeight / 2;
            }
        }
        public void SetPixel(int x, int y, Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas[x, y] = color; break;
                case "VBE": VBECanvas[x, y] = color; break;
            }
        }
        public void DrawRectangle(int x, int y, ushort w, ushort h, ushort radius, Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.DrawRectangle(x, y, w, h, radius, color); break;
                case "VBE": VBECanvas.DrawRectangle(x, y, w, h, radius, color); break;
            }
        }
        public void DrawCircle(int x, int y, ushort radius, Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.DrawCircle(x, y, radius, color); break;
                case "VBE": VBECanvas.DrawCircle(x, y, radius, color); break;
            }
        }
        public void DrawTriangle(int x, int y, int x1, int y1, int x2, int y2, Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.DrawTriangle(x, y, x1, y1, x2, y2, color); break;
                case "VBE": VBECanvas.DrawTriangle(x, y, x1, y1, x2, y2, color); break;
            }
        }
        public void DrawLine(int x, int y, int x1, int y1, Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.DrawLine(x, y, x1, x1, color); break;
                case "VBE": VBECanvas.DrawLine(x, y, x1, y1, color); break;
            }
        }
        public void DrawString(int x, int y, string text, Color color, Font font)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.DrawString(x, y, text, font, color); break;
                case "VBE": VBECanvas.DrawString(x, y, text, font, color); break;
            }
        }
        public void DrawFilledRectangle(int x, int y, ushort w, ushort h, ushort radius, Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.DrawFilledRectangle(x, y, w, h, radius, color); break;
                case "VBE": VBECanvas.DrawFilledRectangle(x, y, w, h, radius, color); break;
            }
        }
        public void Update()
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.Update(); break;
                case "VBE": VBECanvas.Update(); break;
            }
        }
        public void Clear(Color color)
        {
            switch (Mode)
            {
                case "SVGAII": SVGAIICanvas.Clear(color); break;
                case "VBE": VBECanvas.Clear(color); break;
            }
        }
    }
}