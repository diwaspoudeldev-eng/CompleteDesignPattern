# Walkthrough: Inversion of Control (IoC) Pattern

This guide walks through the implementation of the Inversion of Control (IoC) principle alongside fundamental Object-Oriented patterns (like Polymorphism and Factory) present in this application.

## Table of Contents
- [1. The Problem: Direct Instantiation & Tight Coupling](#1-the-problem-direct-instantiation--tight-coupling)
- [2. Abstraction via `ICustomer`](#2-abstraction-via-icustomer)
- [3. Applying Inversion of Control (IoC) using a Factory](#3-applying-inversion-of-control-ioc-using-a-factory)
- [4. Polymorphism in Action](#4-polymorphism-in-action)
- [Summary](#summary)

## 1. The Problem: Direct Instantiation & Tight Coupling

In older patterns or legacy code, UI layers often create instances of their dependencies directly. For instance, notice the commented out code inside `FormCustomer.cs`:

```csharp
//if (cmbCustomerType.Text == "Lead")
//{
//    lead = new Lead();
//    cust = null;
//}
//else if (cmbCustomerType.Text == "Customer")
//{
//    cust = new Customer();
//    lead = null;
//}
```

**Issues with this approach:**
- **High Coupling:** The `WindowsForm` project directly depends on the concrete implementations `Customer` and `Lead` from the `MiddleLayer`.
- **Maintenance Nightmare:** Adding a new type of customer means modifying the `FormCustomer` code directly.

## 2. Abstraction via `ICustomer`

To begin the decoupling process, an abstraction (`ICustomer`) was introduced inside the `InterfaceLayer`.

```csharp
public interface ICustomer
{
    string CustomerName { get; set; }
    // ... other properties
    void Validate();
}
```

By relying on `ICustomer` instead of `CustomerBase`, `Customer` or `Lead`, the UI no longer cares about the concrete implementation details, only that the object adheres to the `ICustomer` contract. Both `Customer` and `Lead` in `MiddleLayer` inherit from `CustomerBase` which implements `ICustomer`.

## 3. Applying Inversion of Control (IoC) using a Factory

To achieve Inversion of Control (IoC), the responsibility of instantiating the objects is taken away from the UI code (`FormCustomer`) and inverted/transferred to a specialized component: the `CustomerFactory`.

```csharp
public static class Factory
{
    public static ICustomer Create(string typeOfCustomer)
    {
        if (typeOfCustomer == "Lead") return new Lead();
        else if (typeOfCustomer == "Customer") return new Customer();
        else throw new ArgumentException("Invalid customer type");
    }
}
```

Now, the `FormCustomer` leverages this factory:

```csharp
private ICustomer cust = null;

private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
{
    cust = Factory.Create(cmbCustomerType.Text);
}
```

**Benefits of this setup:**
- **Inversion of Control:** The `FormCustomer` class no longer controls *how* or *when* derived objects are created. The factory handles it.
- **Dependency Inversion Principle:** The high-level module (`UI`) relies on an abstraction (`ICustomer`) and depends on a Factory to provide it.
- **Separation of Concerns:** The instantiation logic is neatly siloed into `CustomerFactory`. 

## 4. Polymorphism in Action

Thanks to Inversion of Control and abstracting to an interface, interacting with any derived `ICustomer` becomes trivial and uniform.

Inside `btnValidate_Click`:

```csharp
private void btnValidate_Click(object sender, EventArgs e)
{
    SetCustomer();
    cust.Validate(); // Polymorphism at play
}
```

No matter whether `Factory.Create()` returned a `Lead` (which implies different validation rules) or a `Customer`, the `cust.Validate()` will invoke the correct overriden method dynamically at runtime. This also adheres to the **Liskov Substitution Principle**, as derived customer classes seamlessly replaced their base implementations without breaking the application logic.

## Summary

1. **Before**: UI dynamically instantiates classes using `new Lead()` - leading to a tightly coupled architecture.
2. **After**: The Factory handles object creation, returning `ICustomer`. The `UI` surrenders instantiation control (IoC) to the `Factory` layer, promoting a scalable and easily testable structure.



