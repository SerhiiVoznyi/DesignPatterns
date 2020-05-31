namespace DesignPatterns.Concurrent
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Chain of Responsibility is a behavioral [Design Pattern] that lets you pass requests along a chain of handlers.
    /// Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TOperation">The type of the operation.</typeparam>
    public interface IChainOfResponsibility<TResult, TOperation>
    {
        /// <summary>
        /// Registers the next.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="nextHandler">The next handler.</param>
        void RegisterNext<TImplementation>(TImplementation nextHandler)
            where TImplementation : IChainOfResponsibility<TResult, TOperation>;

        /// <summary>
        /// Method for handling the operation data asynchronously.
        /// </summary>
        /// <param name="operationData">The operation data.</param>
        Task<TResult> HandleAsync(TOperation operationData);

        /// <summary>
        /// Gets the chain links types from current point.
        /// </summary>
        /// <returns>IEnumerable collection of System.Types.</returns>
        IEnumerable<Type> GetChainLinksTypes();
    }

    /// <summary>
    /// The base implementation of Chain Of Responsibility.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TOperation">The type of the operation.</typeparam>
    /// <seealso cref="DesignPatterns.IChainOfResponsibility{TResult, TOperation}" />
    public abstract class ChainOfResponsibilityBase<TResult, TOperation>
        : IChainOfResponsibility<TResult, TOperation>
    {
        /// <summary>
        /// The next handler in the chain. 
        /// </summary>
        protected IChainOfResponsibility<TResult, TOperation> Next;

        public virtual void RegisterNext<TImplementationType>(TImplementationType nextHandler)
            where TImplementationType : IChainOfResponsibility<TResult, TOperation>
            => this.Next = nextHandler;

        public abstract Task<TResult> HandleAsync(TOperation operationData);

        public virtual IEnumerable<Type> GetChainLinksTypes()
        {
            var result = new List<Type>
            {
                this.GetType(),
            };

            if (this.Next != null)
            {
                result.AddRange(this.Next.GetChainLinksTypes());
            }

            return result;
        }
    }
}
