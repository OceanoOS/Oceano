using System.Collections.Generic;

namespace Oceano.Services
{
    /// <summary>
    /// Task manager, used to manage <see cref="Task"/>
    /// </summary>
    public static class TaskManager
    {
        /// <summary>
        /// Task list.
        /// </summary>
        public static List<Task> tasks = new();
        /// <summary>
        /// Register a new task.
        /// </summary>
        /// <param name="task">Task to add.</param>
        public static void RegisterTask(Task task)
        {
            tasks.Add(task);
        }
        /// <summary>
        /// Update the <see cref="TaskManager"/>.
        /// </summary>
        public static void Update()
        {
            foreach (var task in tasks)
            {
                if (task.priority == Priority.High)
                {
                    task.Run();
                }
                else if (task.priority == Priority.Medium)
                {
                    task.Run();
                }
                else if (task.priority == Priority.Low)
                {
                    task.Run();
                }
            }
        }
    }
}
