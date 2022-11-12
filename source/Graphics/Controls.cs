using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public static class Controls
    {
        public static void DrawButton(this DoubleBufferedVMWareSVGAII vMWareSVGAII,uint x, uint y,string text, Action a = null)
        {
            vMWareSVGAII.DoubleBuffer_DrawFillRectangle(x, y, (uint)text.Length * 8, 16, (uint)Color.FromArgb(32, 32, 32).ToArgb());
            vMWareSVGAII.DrawACSIIString(text, (uint)Color.White.ToArgb(), x, y);
            vMWareSVGAII.DoubleBuffer_DrawRectangle((uint)Color.Cyan.ToArgb(), (int)x, (int)y, text.Length * 8, 16);
            if (MouseManager.X >= x & MouseManager.Y >= y & MouseManager.X <= x + text.Length * 8 & MouseManager.Y <= y + 16 & MouseManager.MouseState==MouseState.Left)
            {
                a();
            }
        }
        public static void DrawMenu(this DoubleBufferedVMWareSVGAII vMWareSVGAII,uint x, uint y,string text1="",string text2="",string text3 = "",string text4 = "" ,Action a1=null,Action a2=null,Action a3 =null,Action a4 = null)
        {
            vMWareSVGAII.DoubleBuffer_DrawFillRectangle(x, y, 100, 64, (uint)Color.FromArgb(32, 32, 32).ToArgb());
            vMWareSVGAII.DrawButton(x, y, text1, a1);
            vMWareSVGAII.DrawButton(x, y+16, text2, a2);
            vMWareSVGAII.DrawButton(x, y+32, text3, a3);
            vMWareSVGAII.DrawButton(x, y+48, text4, a4);
        }
        public static void DrawIcon(this DoubleBufferedVMWareSVGAII vMWareSVGAII,uint x, uint y, Image image,string text,Action a = null)
        {
            vMWareSVGAII.DoubleBuffer_DrawImage(image, x + 4, y);
            vMWareSVGAII.DrawACSIIString(text, (uint)Color.White.ToArgb(), x, y + 32);
            if(MouseManager.X >= x &MouseManager.X <=x+48& MouseManager.Y >=y &MouseManager.Y <= y+48 & MouseManager.MouseState == MouseState.Right)
            {
                a();
            }
        }
    }
}
