using Cosmos.System.Graphics;
using Oceano.Gui.Drivers;
using Oceano.Gui.Drivers.SVGAII;
using Cosmos.HAL;
using Cosmos.System;
namespace Oceano.Gui{
    public class Graphics{
        public Canvas canvas;
        public VMWareSVGAII vMWareSVGAII;
        public string Mode;

        public void Init(string mode = "Auto", bool InitMouse = true){
            this.Mode = mode;
            switch(mode){
                default: 
                    System.Console.WriteLine("Mode not supported.");
                break;
                case "Auto": 
                    canvas = FullScreenCanvas.GetFullScreenCanvas();
                break;
                case "SVGAII": 
                    vMWareSVGAII = new();
                    vMWareSVGAII.SetMode(640,480);
                break;
                case "VGA": 
                    canvas = new VGACanvas();
                    VGAScreen.SetGraphicsMode(VGADriver.ScreenSize.Size640x480,ColorDepth.ColorDepth32);
                break;
            }
            if(InitMouse){
                if(mode == "Auto"){
                MouseManager.ScreenWidth = (uint)canvas.Mode.Width;
                MouseManager.ScreenHeight = (uint)canvas.Mode.Height;
                }
                if(mode == "SVGAII" && mode == "VGA"){
                    MouseManager.ScreenWidth = 640;
                    MouseManager.ScreenHeight = 480;
                }
            }
        }
    }
}