using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Graphics
{
    public class TestApp : App
    {
        public TestApp(uint width, uint height, uint x = 0, uint y = 0) : base(width, height, x, y)
        {
            name = "TestApp";
        }

        public override void _Update()
        {
            Display.vMWareSVGAII.DrawACSIIString("This is a test app made for oceano!", (uint)Color.White.ToArgb(), x, y);
        }
    }
}
