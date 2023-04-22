using System;

namespace Oceano.Shell.Commands
{
    public class Calc : Command
    {
        public Calc(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            try
            {
                int num1 = Convert.ToInt16(args[0]);
                int num2 = Convert.ToInt16(args[2]);
                int result = 0;
                switch (args[1])
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                }
                string response = "Result: " + result.ToString();
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return "";
        }
    }
}
