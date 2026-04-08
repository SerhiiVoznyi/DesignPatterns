namespace DesignPatterns.Tests.Examples;

/// <summary>
///     Visitor extension for <see cref="StringAcceptor"/> so concrete visitors can implement
///     <see cref="VisitString"/> without casting—classic double dispatch for this acceptor type.
/// </summary>
public interface IStringAcceptorVisitor
{
    string VisitString(StringAcceptor acceptor);
}

public class StringAcceptor : IAcceptor<string>
{
    public string Value { get; }

    public StringAcceptor(string value)
    {
        Value = value;
    }

    /// <summary>
    ///     Dispatches to <see cref="IStringAcceptorVisitor.VisitString"/> when the visitor supports it;
    ///     otherwise falls back to <see cref="IVisitor{TResult}.Visit"/>.
    /// </summary>
    public string Accept(IVisitor<string> visitor)
    {
        if (visitor is IStringAcceptorVisitor specific)
            return specific.VisitString(this);
        return visitor.Visit(this);
    }
}

public class UpperCaseVisitor : IVisitor<string>, IStringAcceptorVisitor
{
    public string VisitString(StringAcceptor acceptor) => acceptor.Value.ToUpperInvariant();

    public string Visit(IAcceptor<string> acceptor)
    {
        return acceptor switch
        {
            StringAcceptor s => VisitString(s),
            _ => throw new System.NotSupportedException($"No visit overload for {acceptor.GetType().Name}.")
        };
    }
}
