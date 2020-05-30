namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Tests.Models;
    using System;
    using System.Collections.Generic;

    public class FactoryMethodExample : IFactoryMethod<CompositionRoot>
    {
        public CompositionRoot Instantiate()
            => new CompositionRoot
            {
                Company = new Company
                {
                    Id = 1,
                    Area = new Area
                    {
                        Id = 1,
                        AreaCode = 1,
                        AreaName = "Test Name"
                    },
                    CompanyName = "Test Company Name"
                },
                Customers = new List<Customer>
                {
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Customer Name",
                        Birthdate = DateTime.Now
                    }
                }
            };
    }
}
