namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// The representation of Acceptor interface
    /// as part of implementation of [Visitor] [Design Pattern]
    /// </summary>
    public interface IAcceptor
    {
        /// <summary>
        /// Accepts the specified visitor asynchronously.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        Task AcceptAsync(IVisitor visitor);
    }

    /// <summary>
    /// The representation of Acceptor interface
    /// as part of implementation of [Visitor] [Design Pattern]
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAcceptor<TResult>
    {
        /// <summary>
        /// Accepts the specified visitor asynchronously.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        Task<TResult> AcceptAsync(IVisitor<TResult> visitor);
    }

    /// <summary>
    /// Visitor is a behavioral [Design Pattern] that allows adding
    /// new behaviors to existing class hierarchy without altering
    /// any existing code.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Visits the specified acceptor asynchronously.
        /// </summary>
        /// <param name="acceptor">The acceptor.</param>
        Task VisitAsync(IAcceptor acceptor);
    }

    /// <summary>
    /// Visitor is a behavioral [Design Pattern] that allows adding
    /// new behaviors to existing class hierarchy without altering
    /// any existing code.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IVisitor<TResult>
    {
        /// <summary>
        /// Visits the specified acceptor asynchronously.
        /// </summary>
        /// <param name="acceptor">The acceptor.</param>
        Task<TResult> VisitAsync(IAcceptor<TResult> acceptor);
    }
}
