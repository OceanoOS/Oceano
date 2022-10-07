using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using MouseManager = Cosmos.System.MouseManager;
using MouseState = Cosmos.System.MouseState;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel1.UI
{
    public class Button
    {
        private uint x = 0, y = 0, width = 100, height = 30;
        private string text = "Button";
        private bool buttonPressed = false;

        public string Text { get => text; set => text = value; }
        public uint X { get => x; set => x = value; }
        public uint Y { get => y; set => y = value; }
        public uint Width { get => width; set => width = value; }
        public uint Height { get => height; set => height = value; }
        public bool ButtonPressed { get => buttonPressed; }

        public void Draw(Canvas c)
        {
            // Draw button rectangle
            c.DrawFilledRectangle(new Pen(Color.FromArgb(240, 240, 240)), (int)X, (int)Y, (int)Width, (int)Height);
            // Draw button border
            c.DrawRectangle(new Pen(Color.FromArgb(0, 162, 232), 1), (int)X, (int)Y, (int)Width, (int)Height);
            // Draw button text
            int stringWidth = text.Length * PCScreenFont.Default.Width;
            int textX = (int)this.X + (int)this.Width / 2 - stringWidth / 2;
            int textY = (int)this.Y + (int)this.Height / 2 - PCScreenFont.Default.Height / 2;
            c.DrawString(Text, PCScreenFont.Default, new Pen(Color.Black), textX, textY);
        }

        public void Update()
        {
            // Detect if the cursor is in the button rectangle and the mouse left button is pressed.
            if (MouseManager.X > X && MouseManager.X < X + Width && MouseManager.Y > Y && MouseManager.Y < Y + Height && MouseManager.MouseState == MouseState.Left)
            {
                buttonPressed = true;
            }
            else
            {
                buttonPressed = false;
            }
        }
    }
}