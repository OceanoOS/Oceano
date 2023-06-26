using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Services
{
    public class Task
    {
        public Priority priority;
        public string name, description;
        public Action a;
        public bool running;
        public Task(string name, string description, Priority priority, Action a, bool running)
        {
            this.name = name;
            this.description = description;
            this.priority = priority;
            this.a = a;
            this.running = running;
        }
        public void Run()
        {
            if(running)
            {
                a();
            }
        }
        public void Kill()
        {
            if (running)
            {
                running = false;
            }
        }
    }
}
