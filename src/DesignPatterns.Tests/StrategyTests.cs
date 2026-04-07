using DesignPatterns.Tests.Examples;
using Shouldly;
using Xunit;

namespace DesignPatterns.Tests;

public class StrategyTests
{
    [Fact]
    public void Execute_Should_ApplyUpperCaseStrategy()
    {
        IStrategy<string, string> strategy = new UpperCaseStrategy();

        var result = strategy.Execute("hello world");

        result.ShouldBe("HELLO WORLD");
    }

    [Fact]
    public void Execute_Should_ApplyLowerCaseStrategy()
    {
        IStrategy<string, string> strategy = new LowerCaseStrategy();

        var result = strategy.Execute("HELLO WORLD");

        result.ShouldBe("hello world");
    }

    [Fact]
    public void Execute_Should_BeInterchangeable()
    {
        var input = "Hello World";
        IStrategy<string, string> upper = new UpperCaseStrategy();
        IStrategy<string, string> lower = new LowerCaseStrategy();

        upper.Execute(input).ShouldBe("HELLO WORLD");
        lower.Execute(input).ShouldBe("hello world");
    }
}
