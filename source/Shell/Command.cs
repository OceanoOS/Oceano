namespace Oceano.Shell
{
    /// <summary>
    /// This is the base class all commands must inherit.
    /// </summary>
    public abstract class Command
    {
        public Command()
        {
            CommandManager.Commands.Add(this);
        }

        #region Methods

        public abstract string Invoke(string[] Args);

        #endregion

        #region Fields

        public string Description { get; set; }
        public string Name { get; set; }

        #endregion
    }
}