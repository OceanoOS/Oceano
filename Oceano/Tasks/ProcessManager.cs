using Oceano.Tasks.Processes;
using System.Collections.Generic;

namespace Oceano.Tasks
{
    public class ProcessManager
    {
        public List<Process> Tasks { get; set; }
        public ProcessManager()
        {
            Tasks = new();
            this.Tasks.Add(new ShellProcess());
            this.Tasks.Add(new MemoryProcess());
        }
        public void Run()
        {
            foreach (var process in Tasks)
            {
                if (process.Priority == Priority.High)
                {
                    process.Run();
                }
                else if (process.Priority == Priority.Medium)
                {
                    process.Run();
                }
                else if (process.Priority == Priority.Low)
                {
                    process.Run();
                }
            }
        }
    }
}
