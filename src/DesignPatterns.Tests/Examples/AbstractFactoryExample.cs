namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Tests.Models;

    public class CompanyFactory : IAbstractFactory<Company, string>
    {
        public Company Create(string operationData)
        {
            return new Company
            {
                Id = operationData.GetHashCode(),
                CompanyName = operationData
            };
        }
    }
}
