# Walkthrough: RIP (Replace If with Polymorphism) Pattern

This guide demonstrates the RIP (Replace If with Polymorphism) pattern used in this application, showcasing how conditional logic is refactored into polymorphic behavior.

## Table of Contents
- [1. The Conditional Code Problem](#1-the-conditional-code-problem)
- [2. Applying Polymorphism via Interfaces](#2-applying-polymorphism-via-interfaces)
- [3. Implementing Specific Behaviors](#3-implementing-specific-behaviors)
- [4. The Refactored UI Code (RIP in Action)](#4-the-refactored-ui-code-rip-in-action)
- [Summary](#summary)

## 1. The Conditional Code Problem

Often, developers write procedural code relying heavily on `if`/`else` or `switch` statements to execute specific logic based on object types. Without RIP, the validation logic in the UI form might look like this:

```csharp
// Example of BAD procedural code:
if (cmbCustomerType.Text == "Customer") 
{
    if (txtCustomerName.Text == "") throw new Exception("Name required");
    if (txtBillingAmount.Text == "") throw new Exception("Amount required");
}
else if (cmbCustomerType.Text == "Lead") 
{
    if (txtCustomerName.Text == "") throw new Exception("Name required");
    // Leads don't need billing amount
}
```

This creates brittle code. Every time a new rule is added, the giant `if` blocks in the UI need modification.

## 2. Applying Polymorphism via Interfaces

To eliminate the `if`/`else` logic, we define a polymorphic method inside our abstraction. The `ICustomer` interface requires a `Validate()` method:

```csharp
public interface ICustomer
{
    // ... properties ...
    void Validate();
}
```

## 3. Implementing Specific Behaviors

In the `MiddleLayer`, each specific customer type is responsible for its own validation logic by overriding the `Validate` method from the shared `CustomerBase`.

```csharp
public class CustomerBase: ICustomer
{
    // Shared common validation
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
    public override void Validate()
    {
        base.Validate(); // Call shared validation
        
        // Specific validation for real Customers
        if (BillAmount == null)
            throw new Exception("BillAmount is Required");
            
        if (BillDate > DateTime.Now)
            throw new Exception("BillDate is Required");
    }
}

public class Lead : CustomerBase
{
    // Uses the base validation without any extra requirements
}
```

## 4. The Refactored UI Code (RIP in Action)

Now, the UI form simply relies on the Factory to provide an instance, and then it invokes the dynamically appropriate `Validate()` method. **The `if` statement is completely replaced by polymorphism.**

```csharp
private void btnValidate_Click(object sender, EventArgs e)
{
    try
    {
        SetCustomer();
        // RIP Pattern, Polymorphism, Liskov Substitution Principle
        cust.Validate(); 
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message.ToString());
    }
}
```

## Summary

The **Replace If with Polymorphism (RIP)** refactoring drastically improves the application by:
1. **Removing branching logic** (`if`/`else`, `switch`) that checks for an object's type.
2. **Delegating responsibility** so each class encapsulates its unique business logic.
3. Keeping the client code (the UI form) perfectly ignorant of the inner workings. Calling `.Validate()` "just works" depending on what type the factory materialized at runtime.
