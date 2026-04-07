using DesignPatterns.Tests.Models;

namespace DesignPatterns.Tests.Examples;

public class CompanyBridge : IBridge<Company>
{
    public Company Implementer { get; }

    public CompanyBridge(Company implementer)
    {
        Implementer = implementer;
    }
}
