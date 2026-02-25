using InterfaceLayer;
using MiddleLayer;

namespace CustomerFactory
{
    public static class Factory
    {
     
        public static ICustomer Create(string typeOfCustomer)
        {
            ICustomer cust;
            if (typeOfCustomer == "Lead")
            {
                cust = new Lead();
                cust.Validation = new LeadValidation();
            }
            else if (typeOfCustomer == "Customer")
            {
                cust = new Customer();
                cust.Validation = new CustomerValidation();
            }
            else
                throw new ArgumentException("Invalid customer type");

            return cust;
        }
    }
}
