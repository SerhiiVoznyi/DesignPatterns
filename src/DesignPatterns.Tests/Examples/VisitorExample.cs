namespace DesignPatterns.Tests.Examples;

public class StringAcceptor : IAcceptor<string>
{
    public string Value { get; }

    public StringAcceptor(string value)
    {
        Value = value;
    }

    public string Accept(IVisitor<string> visitor)
    {
        return visitor.Visit(this);
    }
}

public class UpperCaseVisitor : IVisitor<string>
{
    public string Visit(IAcceptor<string> acceptor)
    {
        var stringAcceptor = (StringAcceptor)acceptor;
        return stringAcceptor.Value.ToUpperInvariant();
    }
}
