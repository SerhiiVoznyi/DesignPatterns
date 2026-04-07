using System;

namespace DesignPatterns.Tests.Models;

public class Customer
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public DateTime? Birthdate { get; set; }
}
