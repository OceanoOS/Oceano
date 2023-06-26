using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Services
{
    public static class TaskManager
    {
        public static List<Task> tasks = new();
        public static void RegisterTask(Task task)
        {
            tasks.Add(task);
        }
        public static void Update()
        {
            foreach(var task in tasks)
            {
                if(task.priority == Priority.High)
                {
                    task.Run();
                }
                else if(task.priority == Priority.Medium)
                {
                    task.Run();
                }
                else if(task.priority == Priority.Low)
                {
                    task.Run();
                }
            }
        }
    }
}
