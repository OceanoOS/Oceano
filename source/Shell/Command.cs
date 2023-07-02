namespace Oceano.Shell
{
    /// <summary>
    /// Command class, used to process a user string to the os.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Name and description of the command.
        /// </summary>
        public readonly string name, description;
        /// <summary>
        /// Initialize command 
        /// </summary>
        /// <param name="name">Name of the command.</param>
        /// <param name="description">Description or function of the command.</param>
        public Command(string name, string description) { this.name = name; this.description = description; } 
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="args">Arguments.</param>
        /// <returns>Print the output.</returns>
        public virtual string Execute(string[] args)
        {
            return "";
        }

    }
}
