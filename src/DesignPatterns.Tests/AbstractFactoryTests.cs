using DesignPatterns.Tests.Examples;
using Shouldly;
using Xunit;

namespace DesignPatterns.Tests;

public class AbstractFactoryTests
{
    [Fact]
    public void Create_Should_ReturnInstanceFromInput()
    {
        var factory = new CompanyFactory();

        var result = factory.Create("Acme Corp");

        result.ShouldNotBeNull();
        result.CompanyName.ShouldBe("Acme Corp");
    }

    [Fact]
    public void Create_Should_ReturnDistinctInstances()
    {
        var factory = new CompanyFactory();

        var result1 = factory.Create("Company A");
        var result2 = factory.Create("Company B");

        result1.ShouldNotBe(result2);
        result1.CompanyName.ShouldNotBe(result2.CompanyName);
    }
}
