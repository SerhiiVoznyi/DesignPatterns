using AutoFixture;

namespace DesignPatterns.Tests;

public abstract class TestBase
{
    protected readonly Fixture Fixture;

    protected TestBase()
    {
        Fixture = new Fixture();
    }
}
