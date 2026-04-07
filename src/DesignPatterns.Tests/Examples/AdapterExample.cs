using DesignPatterns.Tests.Models;

namespace DesignPatterns.Tests.Examples;

public class CustomerToCompanyAdapter : IAdapter<Customer, Company>
{
    public Company Adapt(Customer source)
    {
        return new Company
        {
            Id = source.Id.GetHashCode(),
            CompanyName = source.Name
        };
    }
}
