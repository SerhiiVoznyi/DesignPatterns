namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// Command is behavioral [Design Pattern] that converts requests
    /// or simple operations into objects.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes this command asynchronously.
        /// </summary>
        Task ExecuteAsync();
    }

    /// <summary>
    /// Command is behavioral [Design Pattern] that converts requests
    /// or simple operations into objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface ICommand<TResult>
    {
        /// <summary>
        /// Executes this command asynchronously.
        /// </summary>
        Task<TResult> ExecuteAsync();
    }

    /// <summary>
    /// Command is behavioral [Design Pattern] that converts requests
    /// or simple operations into objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TExecutor">The type of the executor.</typeparam>
    public interface ICommand<TResult, in TExecutor>
    {
        /// <summary>
        /// Executes this command asynchronously.
        /// </summary>
        /// <param name="executor">The executor on which depends this command.</param>
        Task<TResult> Execute(TExecutor executor);
    }
}
