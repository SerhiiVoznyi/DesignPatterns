namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Tests.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrototypeExample : CompositionRoot, IPrototype<PrototypeExample>
    {
        public PrototypeExample()
        {
            this.State = new ImmutableObject("First Time Object", new DateTime(2020, 1, 1));
            this.Customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Name",
                    Birthdate = new DateTime(1991, 10, 13)
                }
            };
        }

        public ImmutableObject State { get; protected set; }

        [Obsolete]
        public PrototypeExample Clone()
        {
            var clone = (PrototypeExample)this.MemberwiseClone();

            clone.State = new ImmutableObject(this.State.Name, this.State.PointInTime);
            clone.Customers = new List<Customer>();
            clone.Customers.AddRange(Customers.Select(s => new Customer
            {
                Id = s.Id,
                Name = string.Copy(s.Name),
                Birthdate = s.Birthdate
            }));
            clone.Company = new Company
            {
                Id = this.Company.Id,
                CompanyName = string.Copy(Company.CompanyName),
                Area = new Area
                {
                    Id = Company.Area.Id,
                    AreaName = string.Copy(Company.Area.AreaName),
                    AreaCode = Company.Area.AreaCode
                }
            };

            return clone;
        }
    }
}
