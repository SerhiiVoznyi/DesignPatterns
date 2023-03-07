namespace DesignPatterns.Tests
{
    using AutoFixture;

    public abstract class TestBase
    {
        protected readonly Fixture Fixture;

        protected TestBase()
        {
            Fixture = new Fixture();
        }
    }
}
