using InterfaceLayer;
using MiddleLayer;

namespace CustomerFactory
{
    public static class Factory
    {
     
        public static ICustomer Create(string typeOfCustomer)
        {
            ICustomer cust;
            switch (typeOfCustomer)
            {
                case "Lead":
                    cust = new Lead();
                    cust.Validation = new PhoneValidationDecorator(
                                        new NameValidationDecorator(
                                            new BaseValidation<ICustomer>()));
                    break;
                case "Customer":
                    cust = new Customer();
                    cust.Validation = new AddressValidationDecorator(
                                        new BillValidationDecorator(
                                            new PhoneValidationDecorator(
                                                new NameValidationDecorator(
                                                    new BaseValidation<ICustomer>()))));
                    break;
                case "SelfService":
                    cust = new SelfService();
                    cust.Validation = new PhoneValidationDecorator(
                                        new NameValidationDecorator(
                                            new BaseValidation<ICustomer>()));
                    break;
                case "HomeDelivery":
                    cust = new HomeDelivery();
                    cust.Validation = new AddressValidationDecorator(
                                        new NameValidationDecorator(
                                            new BaseValidation<ICustomer>()));
                    break;
                default:
                    throw new ArgumentException("Invalid customer type");
            }

            return cust;
        }
    }
}
