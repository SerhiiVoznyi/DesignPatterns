using DesignPatterns.Tests.Models;

namespace DesignPatterns.Tests.Examples;

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
