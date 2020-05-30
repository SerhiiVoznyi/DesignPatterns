namespace DesignPatterns.Tests.Models
{
    using System;

    public class Customer
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
