using System.Collections.Generic;

namespace DesignPatterns.Tests.Models;

public class CompositionRoot
{
    public List<Customer> Customers { get; set; }

    public Company Company { get; set; }
}
