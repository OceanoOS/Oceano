using System;

namespace Oceano.Services
{
    /// <summary>
    /// Task class, used to make loop running simultaneously.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Priority of the task.
        /// </summary>
        public Priority priority;
        /// <summary>
        /// Name and description of the task.
        /// </summary>
        public string name, description;
        /// <summary>
        /// Action of the task.
        /// </summary>
        public Action a;
        /// <summary>
        /// Check if the task is running.
        /// </summary>
        public bool running;
        /// <summary>
        /// Initialize a new task.
        /// </summary>
        /// <param name="name">Name of the task.</param>
        /// <param name="description">Description of the task.</param>
        /// <param name="priority">Priority of the task.</param>
        /// <param name="a">Action of the task.</param>
        /// <param name="running">Set if a task is running or not.</param>
        public Task(string name, string description, Priority priority, Action a, bool running)
        {
            this.name = name;
            this.description = description;
            this.priority = priority;
            this.a = a;
            this.running = running;
        }
        /// <summary>
        /// Update the task.
        /// </summary>
        public void Run()
        {
            if (running)
            {
                a();
            }
        }
        /// <summary>
        /// Kill (Delete) the task.
        /// </summary>
        public void Kill()
        {
            if (running)
            {
                running = false;
            }
        }
    }
}
