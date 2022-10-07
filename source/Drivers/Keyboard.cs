using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyboardManager = Cosmos.System.KeyboardManager;

namespace Oceano.Drivers
{
    public class Keyboard
    {
        public static bool CtrlPressed = false;
        public static bool AltPressed = false;
        public static bool ShiftPressed = false;
        public static void Check()
        {
            if (KeyboardManager.ControlPressed)
            {
                CtrlPressed = true;
            }
            else
            {
                CtrlPressed &= false;
            }
            if (KeyboardManager.AltPressed)
            {
                AltPressed = true;
            }
            else
            {
                AltPressed = false;    
            }
            if (KeyboardManager.ShiftPressed)
            {
                ShiftPressed = true;
            }
            else
            {
                ShiftPressed = false;
            }
        }
    }
}
