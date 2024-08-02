using System;

namespace DesignPatterns.Tests
{
    using DesignPatterns.Tests.Examples;
    using DesignPatterns.Tests.Models;
    using Shouldly;
    using Xunit;

    public class SingletonTests
    {
        [Fact]
        public void GetInstance_Should_ReturnSameObject()
        {
            var instance1 = new SingeltonExample().GetInstance();
            var instance2 = new SingeltonExample().GetInstance();

            instance1.Company = new Company();

            instance1.ShouldBe(instance2);
            instance2.Company.ShouldBe(instance1.Company);
        }

        [Fact]
        public void D()
        {
            var instance1 = DateTime.MinValue.ToString("O");
            instance1.ShouldBe("");
        }
    }
}
