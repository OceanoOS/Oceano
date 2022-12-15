using Cosmos.System;

namespace Oceano.Gui{
    public class Settings : App{
        public Settings(int w,int h, int x = 0, int y = 0) : base(x,y,w,h,"Settings"){

        }
        public override void _Update()
        {
            Kernel.canvas.DrawString("Mouse Sensivity",Graphics.font,Graphics.white,x+2,y+30);
            Kernel.canvas.DrawButton(x+2,y+50,"1",SetMS1);
            Kernel.canvas.DrawButton(x+20,y+50,"2",SetMS2);
        }
        public void SetMS1(){
            MouseManager.MouseSensitivity = 1;
        }
        public void SetMS2(){
            MouseManager.MouseSensitivity = 2;
        }
    }
}