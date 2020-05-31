namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// The classic interface for the [Builder] Design Pattern.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilder<TResult>
    {
        /// <summary>
        /// Builds a object asynchronously.
        /// </summary>
        Task<TResult> BuildAsync();
    }
}
