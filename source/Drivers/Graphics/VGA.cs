using Cosmos.HAL.Drivers.Video;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Drivers.Graphics
{
    public class VGA : Display
    {
        public VGADriver Device;
        public uint ScreenWidth, ScreenHeight;
        public override void Init()
        {
            Device.SetGraphicsMode(VGADriver.ScreenSize.Size640x480, VGADriver.ColorDepth.BitDepth4);
        }
        public override void Init(uint Width, uint Height)
        {
            if(Width == 320 & Height == 200)
            {
                Device.SetGraphicsMode(VGADriver.ScreenSize.Size320x200, VGADriver.ColorDepth.BitDepth8);
                ScreenWidth = 320;
                ScreenHeight = 200;
            }
            if (Width == 640 & Height == 480)
            {
                Device.SetGraphicsMode(VGADriver.ScreenSize.Size640x480, VGADriver.ColorDepth.BitDepth4);
                ScreenWidth = 640;
                ScreenHeight = 480;
            }
            if (Width == 720 & Height == 480)
            {
                Device.SetGraphicsMode(VGADriver.ScreenSize.Size720x480, VGADriver.ColorDepth.BitDepth4);
                ScreenWidth = 720;
                ScreenHeight = 480;
            }
        }
        public override void Update()
        {
        
        }
    }
}
