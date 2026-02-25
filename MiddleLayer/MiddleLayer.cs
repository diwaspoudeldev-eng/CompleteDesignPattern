using InterfaceLayer;

namespace MiddleLayer;

public class LeadValidation : IValidation<ICustomer>
{
    public void Validate(ICustomer entity)
    {
        if (string.IsNullOrWhiteSpace(entity.CustomerName))
            throw new Exception("Customer Name is required");

        if (string.IsNullOrWhiteSpace(entity.PhoneNumber))
            throw new Exception("Phone Number is required");
    }
}

public class CustomerValidation : IValidation<ICustomer>
{
    public void Validate(ICustomer entity)
    {
        if (string.IsNullOrWhiteSpace(entity.CustomerName))
            throw new Exception("Customer Name is required");

        if (string.IsNullOrWhiteSpace(entity.PhoneNumber))
            throw new Exception("Phone Number is required");

        if (entity.BillAmount == null || entity.BillAmount == 0)
        {
            throw new Exception("Bill Amount is Required");
        }
        if (entity.BillDate == null || entity.BillDate > DateTime.Now)
        {
            throw new Exception("Bill Date is Required and cannot be in future");
        }
    }
}

public class CustomerBase : ICustomer
{
    public string CustomerName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public decimal? BillAmount { get; set; }
    public DateTime? BillDate { get; set; }
    public string Address { get; set; } = "";
    public IValidation<ICustomer> Validation { get; set; }

    public virtual void Validate()
    {
        Validation.Validate(this);
    }
}

public class Customer : CustomerBase
{
}

public class Lead : CustomerBase
{
}