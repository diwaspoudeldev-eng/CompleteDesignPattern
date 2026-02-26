# Walkthrough: Generic Strategy Pattern for Validation

## Navigation
- [Changes Made](#changes-made)
    - [1. Created Generic Interface](#1-created-generic-interface)
    - [2. Implemented Concrete Strategies](#2-implemented-concrete-strategies)
    - [3. Updated Customer Hierarchy](#3-updated-customer-hierarchy)
    - [4. Dependency Injection via Factory](#4-dependency-injection-via-factory)
- [Why use the Strategy Pattern here?](#why-use-the-strategy-pattern-here)
- [Validation Results](#validation-results)

---

I have implemented the Generic Strategy Pattern to handle customer validation. This decouples the validation logic from the data objects and the UI.

## Changes Made

### 1. Created Generic Interface
Defined [IValidation.cs](../InterfaceLayer/IValidation.cs) in the `InterfaceLayer`.
```csharp
public interface IValidation<T>
{
    void Validate(T entity);
}
```
[↑ Back to top](#navigation)

### 2. Implemented Concrete Strategies
Added `LeadValidation` and `CustomerValidation` to [MiddleLayer.cs](../MiddleLayer/MiddleLayer.cs). These classes contain the specific business rules for each type.

[↑ Back to top](#navigation)

### 3. Updated Customer Hierarchy
- [ICustomer](../InterfaceLayer/ICustomer.cs) now has a `Validation` property.
- `CustomerBase.Validate()` now delegates the work to the strategy:
```csharp
public virtual void Validate()
{
    Validation.Validate(this);
}
```
[↑ Back to top](#navigation)

### 4. Dependency Injection via Factory
The [CustomerFactory](../CustomerFactory/CustomerFactory.cs) now injects the appropriate strategy during object creation.

[↑ Back to top](#navigation)

> [!IMPORTANT]
> **Why use the Strategy Pattern here?**
> 
> 1. **Separation of Concerns**: The `Customer` classes are now "clean" and only hold data. The validation logic is moved to dedicated logic classes.
> 2. **Open/Closed Principle**: Add new validation rules without changing base classes.
> 3. **Generic Reuse**: `IValidation<T>` can be used for any entity in your system.
> 4. **Testability**: Test logic in isolation without UI dependencies.

> [!TIP]
> **Validation Results**
> The solution builds successfully. The UI now triggers specific rules for "Lead" vs "Customer" without any type-casting or project dependencies on the MiddleLayer concrete classes.
