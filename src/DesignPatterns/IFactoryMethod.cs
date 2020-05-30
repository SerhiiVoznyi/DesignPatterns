namespace DesignPatterns
{
    /// <summary>
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate.
    /// Factory Method lets a class defer instantiation to subclasses.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IFactoryMethod<out TResult>
    {
        /// <summary>
        /// Instantiates this object
        /// <see>
        ///     <cref>{TResult}</cref>
        /// </see>
        /// </summary>
        TResult Instantiate();
    }
}
