namespace DesignPatterns.Tests
{
    using AutoFixture;
    using DesignPatterns.Tests.Examples;
    using DesignPatterns.Tests.Models;
    using Shouldly;
    using Xunit;

    public class CommandTests : TestBase
    {
        [Fact]
        public void Execute_Should_AddCustomerToRoot()
        {
            var root = new CompositionRoot();
            var customer = Fixture.Create<Customer>();
            var command = new AddCustomerCommand(root);

            var result = command.Execute(customer);

            result.ShouldBe(root);
            result.Customers.ShouldContain(customer);
        }

        [Fact]
        public void Execute_Should_AccumulateMultipleCustomers()
        {
            var root = new CompositionRoot();
            var customer1 = Fixture.Create<Customer>();
            var customer2 = Fixture.Create<Customer>();
            var command = new AddCustomerCommand(root);

            command.Execute(customer1);
            command.Execute(customer2);

            root.Customers.Count.ShouldBe(2);
            root.Customers.ShouldContain(customer1);
            root.Customers.ShouldContain(customer2);
        }
    }
}
