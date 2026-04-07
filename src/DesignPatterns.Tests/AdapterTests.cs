namespace DesignPatterns.Tests
{
    using DesignPatterns.Tests.Examples;
    using DesignPatterns.Tests.Models;
    using Shouldly;
    using System;
    using Xunit;

    public class AdapterTests : TestBase
    {
        [Fact]
        public void Adapt_Should_TransformSourceToResult()
        {
            var adapter = new CustomerToCompanyAdapter();
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "John Doe"
            };

            var company = adapter.Adapt(customer);

            company.ShouldNotBeNull();
            company.CompanyName.ShouldBe("John Doe");
        }
    }
}
