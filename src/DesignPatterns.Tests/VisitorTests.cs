using DesignPatterns.Tests.Examples;
using Shouldly;
using Xunit;

namespace DesignPatterns.Tests;

public class VisitorTests
{
    [Fact]
    public void Accept_Should_DelegateToVisitor()
    {
        var acceptor = new StringAcceptor("hello");
        var visitor = new UpperCaseVisitor();

        var result = acceptor.Accept(visitor);

        result.ShouldBe("HELLO");
    }

    [Fact]
    public void Visit_Should_TransformAcceptorValue()
    {
        var acceptor = new StringAcceptor("world");
        var visitor = new UpperCaseVisitor();

        var result = visitor.Visit(acceptor);

        result.ShouldBe("WORLD");
    }
}
