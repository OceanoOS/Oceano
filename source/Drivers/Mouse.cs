using Oceano.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MouseManager = Cosmos.System.MouseManager;

namespace Oceano.Drivers
{
    public class Mouse
    {
        public static bool LeftPressed = false;
        public static bool RightPressed = false;
        public static bool MiddlePressed = false;
        public static void Check()
        {
            if (MouseManager.MouseState == Cosmos.System.MouseState.Left)
            {
                LeftPressed = true;
            }
            else
            {
                LeftPressed = false;
            }
            if (MouseManager.MouseState != Cosmos.System.MouseState.Right)
            {
                RightPressed = true;
            }
            else
            {
                RightPressed = false;
            }
            if (MouseManager.MouseState == Cosmos.System.MouseState.Middle)
            {
                MiddlePressed = true;
            }
            else 
            {
                MiddlePressed = false;
            }
        }
    }
}
