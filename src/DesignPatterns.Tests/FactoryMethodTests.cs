using DesignPatterns.Tests.Examples;
using Shouldly;
using Xunit;

namespace DesignPatterns.Tests;

public class FactoryMethodTests
{
    [Fact]
    public void Instantiate_Should_ReturnNewInstance()
    {
        var factory = new FactoryMethodExample();

        var result = factory.Instantiate();

        result.ShouldNotBeNull();
        result.Company.ShouldNotBeNull();
        result.Company.CompanyName.ShouldBe("Test Company Name");
        result.Customers.ShouldNotBeEmpty();
        result.Customers.Count.ShouldBe(1);
    }

    [Fact]
    public void Instantiate_Should_ReturnNewInstance_EachCall()
    {
        var factory = new FactoryMethodExample();

        var result1 = factory.Instantiate();
        var result2 = factory.Instantiate();

        result1.ShouldNotBe(result2);
    }
}
