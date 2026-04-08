using AutoFixture;
using DesignPatterns.Implementation;
using DesignPatterns.Tests.Models;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace DesignPatterns.Tests;

public class DistributiveBuilderTests : TestBase
{
    [Fact]
    public void Build_Should_ApplyMutationChain()
    {
        var company = Fixture.Create<Company>();
        var customer = Fixture.Create<Customer>();
        var area = Fixture.Create<Area>();

        var result = new DistributiveBuilderBase<CompositionRoot>()
            .AddMutation(root => root.Company = company)
            .AddMutation(root => root.Customers = new List<Customer> { customer })
            .AddMutation(root => root.Company.Area = area)
            .Build();

        result.ShouldNotBeNull();
        result.Company.ShouldBe(company);
        result.Company.Area.ShouldBe(area);
        result.Customers.ShouldContain(customer);
    }

    [Fact]
    public void Build_Should_SkipException_IfSafe()
    {
        var company = Fixture.Create<Company>();
        var customer = Fixture.Create<Customer>();
        var customerSkipped = Fixture.Create<Customer>();
        var area = Fixture.Create<Area>();

        var result = new DistributiveBuilderBase<CompositionRoot>()
            .AddMutation(root => root.Company = company)
            .AddMutation(root =>
            {
                root.Customers = new List<Customer>
                {
                    customer
                };
            })
            .AddMutation(root =>
            {
                root.Customers.Add(customerSkipped);
                throw new Exception("Test execution should not contain exception.");
            }, true)
            .AddMutation(root => root.Company.Area = area)
            .Build();

        result.ShouldNotBeNull();
        result.Company.ShouldBe(company);
        result.Company.Area.ShouldBe(area);
        result.Customers.ShouldContain(customer);
        result.Customers.ShouldNotContain(customerSkipped);
    }
}
