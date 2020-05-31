namespace DesignPatterns
{
    /// <summary>
    /// The representation of Acceptor interface
    /// as part of implementation of [Visitor] [Design Pattern]
    /// </summary>
    public interface IAcceptor
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The representation of Acceptor interface
    /// as part of implementation of [Visitor] [Design Pattern]
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAcceptor<TResult>
    {
        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        TResult Accept(IVisitor<TResult> visitor);
    }

    /// <summary>
    /// Visitor is a behavioral [Design Pattern] that allows adding
    /// new behaviors to existing class hierarchy without altering
    /// any existing code.
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// Visits the specified acceptor.
        /// </summary>
        /// <param name="acceptor">The acceptor.</param>
        void Visit(IAcceptor acceptor);
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
        /// Visits the specified acceptor.
        /// </summary>
        /// <param name="acceptor">The acceptor.</param>
        TResult Visit(IAcceptor<TResult> acceptor);
    }
}
