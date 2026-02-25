namespace InterfaceLayer
{
    public interface ICustomer
    {
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        void Validate();
    }
}
