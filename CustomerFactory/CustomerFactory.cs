using MiddleLayer;

namespace CustomerFactory
{
    public static class Factory
    {
     
        public static CustomerBase Create(string typeOfCustomer) //Faction method to create instances of Lead or Customer based on the input string
        {
            // Simple factory method to create instances of Lead or Customer based on the input string
            if (typeOfCustomer == "Lead")
            {
                return new Lead();
            }
            else if (typeOfCustomer == "Customer")
            {
                return new Customer();
            }
            else
                throw new ArgumentException("Invalid customer type");
        }
    }
}
