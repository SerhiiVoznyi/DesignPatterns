namespace DesignPatterns.Tests
{
    using AutoFixture;

    public abstract class TestBase
    {
        protected readonly Fixture Fixture;

        protected TestBase()
        {
            this.Fixture = new Fixture();
        }
    }
}
