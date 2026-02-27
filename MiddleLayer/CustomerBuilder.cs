using System;
using InterfaceLayer;
using CustomerFactory;

namespace MiddleLayer
{
    public class CustomerBuilder : ICustomerBuilder
    {
        private ICustomer _customer;

        public CustomerBuilder(string customerType)
        {
            // The Builder can use the Factory to get the right starting object
            _customer = Factory.Create(customerType);
        }

        public ICustomerBuilder WithId(int id)
        {
            _customer.Id = id;
            return this;
        }

        public ICustomerBuilder WithName(string name)
        {
            _customer.CustomerName = name;
            return this;
        }

        public ICustomerBuilder WithPhone(string phone)
        {
            _customer.PhoneNumber = phone;
            return this;
        }

        public ICustomerBuilder WithBilling(decimal? amount, DateTime? date)
        {
            _customer.BillAmount = amount;
            _customer.BillDate = date;
            return this;
        }

        public ICustomerBuilder WithAddress(string address)
        {
            _customer.Address = address;
            return this;
        }

        public ICustomer Build()
        {
            return _customer;
        }
    }
}
