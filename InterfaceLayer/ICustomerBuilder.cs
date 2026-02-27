using System;

namespace InterfaceLayer
{
    public interface ICustomerBuilder
    {
        ICustomerBuilder WithId(int id);
        ICustomerBuilder WithName(string name);
        ICustomerBuilder WithPhone(string phone);
        ICustomerBuilder WithBilling(decimal? amount, DateTime? date);
        ICustomerBuilder WithAddress(string address);
        ICustomer Build();
    }
}
