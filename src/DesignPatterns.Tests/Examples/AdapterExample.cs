namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Tests.Models;

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
}
