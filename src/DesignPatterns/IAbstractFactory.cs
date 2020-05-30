namespace DesignPatterns
{
    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects].
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="operationData">The operation data.</param>
        TResult Create<TResult, TInput>(TInput operationData);
    }

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAbstractFactory<out TResult>
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects].
        /// </summary>
        TResult Create();
    }

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    public interface IAbstractFactory<out TResult, in TInput>
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects].
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        TResult Create(TInput operationData);
    }
}
