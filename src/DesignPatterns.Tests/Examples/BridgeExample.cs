namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Tests.Models;

    public class CompanyBridge : IBridge<Company>
    {
        public Company Implementer { get; }

        public CompanyBridge(Company implementer)
        {
            Implementer = implementer;
        }
    }
}
