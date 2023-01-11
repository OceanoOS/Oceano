using Oceano.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Commands
{
    public class Fs : Command
    {
        public Fs(string name) : base(name)
        {

        }
        public override string Execute(string[] args)
        {
            string response = "";
            switch (args[0])
            {
                case "init":
                    try
                    {
                        Filesystem.Init();
                        response = "Filesystem initialized successfully!";
                    }catch(Exception e)
                    {
                        response = e.Message;
                    }
                    break;
                
            }
            return response;
        }
    }
}
