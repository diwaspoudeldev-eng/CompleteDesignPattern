# Walkthrough: Factory Pattern

This guide explains how the Factory Pattern is implemented in this application to handle object creation and decouple instantiation logic from the user interface.

## Table of Contents
- [1. The Instantiation Problem](#1-the-instantiation-problem)
- [2. The Factory Implementation](#2-the-factory-implementation)
- [3. Using the Factory in the UI](#3-using-the-factory-in-the-ui)
- [Summary](#summary)

## 1. The Instantiation Problem

In the initial implementation, the UI (`FormCustomer`) was responsible for deciding which specific customer class to instantiate based on user input. 

```csharp
// Inside FormCustomer.cs
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

This violates the **Single Responsibility Principle** (the form should only handle UI logic, not business object creation) and makes the code difficult to maintain. If we added a new customer type (e.g., `VIPCustomer`), we would have to modify the UI code directly.

## 2. The Factory Implementation

To solve this, a Simple Factory was introduced in a separate `CustomerFactory` project.

```csharp
// Inside CustomerFactory.cs
public static class Factory
{
    public static ICustomer Create(string typeOfCustomer)
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
```

The `Factory.Create` method centralizes object creation. It takes a string identifier and returns the appropriate implementation of the `ICustomer` interface. 

## 3. Using the Factory in the UI

Now, the UI delegates the responsibility of creation to the Factory:

```csharp
// Inside FormCustomer.cs
private ICustomer cust = null;

private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
{
    // Factory pattern implementation
    cust = Factory.Create(cmbCustomerType.Text);
}
```

## Summary

By using the Factory Pattern:
1. **Centralized Creation:** Object creation logic is managed in a single place (`CustomerFactory`).
2. **Decoupled Architecture:** The Windows Form only knows about the `ICustomer` interface, not the concrete `Lead` or `Customer` classes.
3. **Open/Closed Principle:** While this is a Simple Factory (and requires modification to add new types), it sets the stage for more advanced factories (like Factory Method) where you can easily register new types without changing existing client code.
