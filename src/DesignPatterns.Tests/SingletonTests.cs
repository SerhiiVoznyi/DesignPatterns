namespace DesignPatterns.Tests
{
    using DesignPatterns.Tests.Examples;
    using Shouldly;
    using Xunit;

    public class SingletonTests
    {
        [Fact]
        public void GetInstance_Should_ReturnSameObject()
        {
            var instance1 = new SingeltonExample().GetInstance();
            var instance2 = new SingeltonExample().GetInstance();

            instance1.ShouldBe(instance2);
        }
    }
}
