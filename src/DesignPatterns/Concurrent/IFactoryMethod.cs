namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate.
    /// Factory Method lets a class defer instantiation to subclasses.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IFactoryMethod<TResult>
    {
        /// <summary>
        /// Instantiates this object asynchronously
        /// <see>
        ///     <cref>{TResult}</cref>
        /// </see>
        /// </summary>
        Task<TResult> InstantiateAsync();
    }
}
