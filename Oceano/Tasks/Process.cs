using Cosmos.HAL;
using Oceano.Core;

namespace Oceano.Tasks
{
    public class Process
    {
        public string Name, Version, Description;
        public Priority Priority;
        public bool Running =true;
        public Process(string name, string version, string description, Priority priority)
        {
            this.Name = name;
            this.Version = version;
            this.Description = description;
            this.Priority = priority;
        }
        public void Kill(ProcessManager processManager)
        {
            try
            {
                processManager.Tasks.Remove(this);
            }
            catch
            {
                Power.ACPIShutdown();
            }
        }
        public virtual void Run()
        {

        }
    }
    public enum Priority
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
}
