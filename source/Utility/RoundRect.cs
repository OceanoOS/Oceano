using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RoundRect
{
    /// <summary>
    /// Provides extension methods for drawing anti-aliased rounded rectangles on a canvas.
    /// </summary>
    public static class RoundRect
    {
        /// <summary>
        /// The offset of the corners.
        /// </summary>
        public static double Offset = 0;

        /// <summary>
        /// The sharpness of the corners.
        /// </summary>
        public static double Sharpness = 0.8;

        private static List<string> CacheKeys = new List<string>();
        private static List<Color[]> CacheValues = new List<Color[]>();

        /// <summary>
        /// Corner type.
        /// </summary>
        public enum Corner
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }

        private static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>
        /// Draw a round anti-aliased corner.
        /// </summary>
        /// <param name="canvas">The canvas to draw on.</param>
        /// <param name="color">The colour of the corner.</param>
        /// <param name="cx">The X position of the corner.</param>
        /// <param name="cy">The Y position of the corner.</param>
        /// <param name="size">The size of the corner.</param>
        /// <param name="corner">The type of corner.</param>
        public static void DrawRoundCorner(this Canvas canvas, Pen pen, int cx, int cy, int size, Corner corner)
        {
            Color originalColor = pen.Color;
            string key = originalColor.R.ToString() + originalColor.G.ToString() + originalColor.B.ToString() + size.ToString() + ((int)corner).ToString();
            int index = -1;
            for (int i = 0; i < CacheKeys.Count; i++)
            {
                if (CacheKeys[i] == key)
                {
                    index = i;
                }
            }
            Color[] values;
            if (index == -1)
            {
                CacheKeys.Add(key);
                values = new Color[(size * size)];
                double lookX = (corner == Corner.TopLeft || corner == Corner.BottomLeft) ? size - 1 : 0;
                double lookY = (corner == Corner.TopLeft || corner == Corner.TopRight) ? size - 1 : 0;
                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        double distance = (Distance(x, y, lookX, lookY) + Offset) / size;
                        byte alpha = (byte)Math.Clamp((1 - distance) * (size * Sharpness) * 255, 0, 255);
                        values[(y * size) + x] = Color.FromArgb(alpha, originalColor);
                    }
                }
                CacheValues.Add(values);
            }
            else
            {
                values = CacheValues[index];
            }
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    pen.Color = values[(y * size) + x];
                    canvas.DrawPoint(pen, cx + x, cy + y);
                }
            }
            pen.Color = originalColor;
        }

        /// <summary>
        /// Draw an anti-aliased rounded rectangle.
        /// </summary>
        /// <param name="canvas">The canvas to draw on.</param>
        /// <param name="color">The colour of the rectangle.</param>
        /// <param name="x">The X position of the rectangle.</param>
        /// <param name="y">The Y position of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="cornerSize">The size of the corners.</param>
        public static void DrawRoundRect(this Canvas canvas, Pen pen, int x, int y, int width, int height, int cornerSize)
        {
            if (cornerSize == 0)
            {
                canvas.DrawFilledRectangle(pen, x, y, width, height);
            }

            int longest = Math.Max(width, height);
            if (cornerSize > longest / 2) cornerSize = longest / 2;

            canvas.DrawFilledRectangle(pen, x, y + cornerSize, width, height - (cornerSize * 2));
            canvas.DrawFilledRectangle(pen, x + cornerSize, y, width - (cornerSize * 2), height);
            DrawRoundCorner(canvas, pen, x, y, cornerSize, Corner.TopLeft);
            DrawRoundCorner(canvas, pen, (x + width) - cornerSize, y, cornerSize, Corner.TopRight);
            DrawRoundCorner(canvas, pen, x, (y + height) - cornerSize, cornerSize, Corner.BottomLeft);
            DrawRoundCorner(canvas, pen, (x + width) - cornerSize, (y + height) - cornerSize, cornerSize, Corner.BottomRight);
        }
    }
}