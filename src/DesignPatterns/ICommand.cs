namespace DesignPatterns
{
    /// <summary>
    /// Command is behavioral [Design Pattern] that converts requests
    /// or simple operations into objects.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Command is behavioral [Design Pattern] that converts requests
    /// or simple operations into objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface ICommand<out TResult>
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        TResult Execute();
    }

    /// <summary>
    /// Command is behavioral [Design Pattern] that converts requests
    /// or simple operations into objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TExecutor">The type of the executor.</typeparam>
    public interface ICommand<out TResult, in TExecutor>
    {
        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <param name="executor">The executor on which depends this command.</param>
        TResult Execute(TExecutor executor);
    }
}
