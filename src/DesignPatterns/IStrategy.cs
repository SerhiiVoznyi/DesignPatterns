namespace DesignPatterns
{
    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance.
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IStrategy<out TResult>
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance.
        /// </summary>
        TResult Execute();
    }

    /// <summary>
    /// Strategy is a behavioral [Design Pattern]
    /// That turns a set of behaviors into objects
    /// And makes them interchangeable inside original context object.
    /// </summary>
    public interface IStrategy<out TResult, in TData>
    {
        /// <summary>
        /// Executes algorithm encapsulated in this strategy instance.
        /// </summary>
        /// <param name="data">The data.</param>
        TResult Execute(TData data);
    }
}
