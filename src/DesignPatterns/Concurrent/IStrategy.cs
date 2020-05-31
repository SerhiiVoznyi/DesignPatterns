namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        Task ExecuteAsync();
    }

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IStrategy<TResult>
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        Task<TResult> Execute();
    }

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    public interface IStrategy<TResult, in TData>
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance asynchronously.
        /// </summary>
        /// <param name="data">The data.</param>
        Task<TResult> Execute(TData data);
    }
}
