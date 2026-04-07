namespace DesignPatterns.Tests.Examples
{
    using DesignPatterns.Tests.Models;
    using System.Collections.Generic;

    public class AddCustomerCommand : ICommand<CompositionRoot, Customer>
    {
        private readonly CompositionRoot _root;

        public AddCustomerCommand(CompositionRoot root)
        {
            _root = root;
        }

        public CompositionRoot Execute(Customer executor)
        {
            _root.Customers ??= new List<Customer>();
            _root.Customers.Add(executor);
            return _root;
        }
    }
}
