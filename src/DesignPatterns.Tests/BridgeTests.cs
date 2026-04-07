namespace DesignPatterns.Tests
{
    using AutoFixture;
    using DesignPatterns.Tests.Examples;
    using DesignPatterns.Tests.Models;
    using Shouldly;
    using Xunit;

    public class BridgeTests : TestBase
    {
        [Fact]
        public void Implementer_Should_ReturnProvidedImplementation()
        {
            var company = Fixture.Create<Company>();
            var bridge = new CompanyBridge(company);

            bridge.Implementer.ShouldBe(company);
        }
    }
}
