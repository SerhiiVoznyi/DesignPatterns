namespace DesignPatterns.Tests.Models
{
    using System.Collections.Generic;

    public class CompositionRoot
    {
        public List<Customer> Customers { get; set; }

        public Company Company { get; set; }
    }
}
