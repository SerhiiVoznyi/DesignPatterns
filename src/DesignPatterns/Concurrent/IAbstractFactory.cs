namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide
    /// an interface for creating families of related objects.
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects] asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="operationData">The operation data.</param>
        /// <returns></returns>
        Task<TResult> CreateAsync<TResult, TInput>(TInput operationData);
    }

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide
    /// an interface for creating families of related objects asynchronously.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAbstractFactory<TResult>
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects] asynchronously.
        /// </summary>
        Task<TResult> CreateAsync();
    }

    /// <summary>
    /// The purpose of the [Abstract Factory] is to provide an interface for creating families of related objects.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    public interface IAbstractFactory<TResult, in TInput>
    {
        /// <summary>
        /// Creates instance of related [object] or [family of objects] asynchronously.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        Task<TResult> CreateAsync(TInput operationData);
    }
}
