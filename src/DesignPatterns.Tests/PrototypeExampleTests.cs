namespace DesignPatterns.Tests
{
    using AutoFixture;
    using DesignPatterns.Tests.Examples;
    using Shouldly;
    using System.Linq;
    using Xunit;

    public class PrototypeExampleTests : TestBase
    {
        [Fact]
        [System.Obsolete]
        public void Clone_Should_CreateNewInstance()
        {
            var prototype = Fixture.Create<PrototypeExample>();

            var clone = prototype.Clone();

            clone.ShouldNotBeNull();
            clone.ShouldNotBe(prototype);
            clone.State.ShouldNotBe(prototype.State);
            clone.Company.ShouldNotBeNull();
            clone.Company.ShouldNotBe(prototype.Company);
            clone.Company.Area.ShouldNotBeNull();
            clone.Company.Area.ShouldNotBe(prototype.Company.Area);
            clone.Customers.ShouldNotBe(prototype.Customers);
            clone.Customers.FirstOrDefault().ShouldNotBe(prototype.Customers.FirstOrDefault());
        }
    }
}
