using Cosmos.System.Graphics;
using System.Drawing;

namespace Oceano.Drivers.Graphics
{
    public abstract class Display
    {
        public abstract void Init();
        public abstract void Init(uint Width, uint Height);
        public abstract void Update();
        public abstract void Clear(Color color);
        public abstract void Clear();
        public abstract uint Width();
        public abstract uint Height();
        public abstract void SetPixel(uint x, uint y, Color color);
        public abstract void DrawLine(uint x1, uint y1, uint x2, uint y2, Color color);
        public abstract void DrawRectangle(uint x, uint y, uint width, uint height, Color color);
        public abstract void DrawFilledRectangle(uint x, uint y, int width, int height, Color color);
        public abstract void DrawImage(uint x, uint y, Image image);
        public abstract void DrawString(string text, uint x, uint y, Color color);
    }
}
