using InterfaceLayer;

namespace MiddleLayer;

public class CustomerBase: ICustomer
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }

    public virtual void Validate()
    {
        if (string.IsNullOrWhiteSpace(CustomerName))
            throw new Exception("Customer Name is required");

        if (string.IsNullOrWhiteSpace(PhoneNumber))
            throw new Exception("Phone Number is required");
    }
}

public class Customer : CustomerBase
{
    public decimal? BillAmount { get; set; }
    public DateTime? BillDate { get; set; }
    public string Address { get; set; }

    public override void Validate()
    {
        base.Validate();
        if (BillAmount == null)
        {
            throw new Exception("BillAmount is Required");
        }
        if (BillDate > DateTime.Now)
        {
            throw new Exception("BillDate is Required");
        }
    }
}

public class Lead : CustomerBase
{
}