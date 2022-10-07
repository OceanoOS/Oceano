using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Boot
{
    public class Boot
    {
        public static bool Configuration = false;
        public static String text = File.ReadAllText(@"0:\boot.cfg");
        public static void ReadBootCfgFile()
        {
            try
            {
                if (text.Contains("[Config]"))
                {
                    Configuration = true;
                }
                else
                {
                    Configuration = false;
                }
                ifgui();
                
            }
            catch
            {
                Configuration=false;
            }
        }
        public static void ifgui()
        {
            if (text.Contains("gui"))
            {
            }
        }
    }
}
