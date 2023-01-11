using Oceano.Core;
using System;

namespace Oceano.Commands
{
    public class Touch : Command
    {
        public Touch(string name) : base(name)
        {

        }
        public override string Execute(string[] args)
        {
            string response = "";
            try 
            {
                Filesystem.fs.CreateFile(args[0]);
                response = "File created successfully";
            }
            catch(Exception ex)
            {
                response = "Error: " + ex.Message; 
            }
            return response;
        }
    }
}
