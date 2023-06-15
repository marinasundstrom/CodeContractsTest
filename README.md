# Code Contracts (Experiment)

A set of attributes that enable compile-time code contracts with requirements and conditions to methods and properties.

They are meant to be analyzed at compile-time or as part of the development experience in an IDE.

The approach is similar to that of Nullable Reference Types.

Analyzer not produced as of yet.

Sample and language syntax proposal below.

## Attributes

* **RequiresAttribute** - Represents a requirement that is applied to a method parameter or property setter.
* **EnsuresAttribute** - Represents a condition that is applied to the return value of a method, a property getter, or a field.
* **ThrowsAttribute** - Indicates that the method or property accessor may throw one or more specific exceptions.

## Details
The information will flow through the program as part of code analysis process.

A local variable that contains the result of a method with contract “ensures” would inherit that information.

This can be expanded to target other elements in code, like fields and generic parameters.

### With existing code

How would this feature play nice with existing code that is not annotated with the contracts?
### Nullable Reference Types

Don’t forget that we have to take into account that we have Nullable Reference Types that can be turned on and off.

Another special case is extension methods.
### Base Class Library

I this were to be adopted, we would have to annotate the whole Base Class Library, just like with Nullable Reference Types.

### Publishing code

The attributes are only applicable when developing. When building an app in Release configuration, the attributes would just be removed.

## Sample
From ContractsTest project:

```c#
// CS1234: Argument does not satisfy requirement: arg < 42
// CS1235: InvalidOperationException is unchecked.
var result = DoSomething(42);
                         ~~

// "result" is marked as satisfying > 0

// CS1234: Argument does not satisfy requirement: input < 0
Foo(result);
    ~~~~~~

[Throws(typeof(InvalidOperationException))]
[return: Ensures("return > 0")]
int DoSomething([Requires("arg >= 0"), Requires("arg < 42")] int arg)
{
    if(arg == 10)
    {
        throw new InvalidOperationException();
    }
    return arg;
}

void Foo([Requires("input < 0")] int input)
{

}
```

## C# Language Syntax Proposal

Based on [Spec#]():

```c#
int DoSomething(int arg)
    requires arg >= 0
    requires arg < 42
    ensures result >= 0
    throws InvalidOperationException
{
    if(arg == 10)
    {
        throw new InvalidOperationException();
    }
    return arg;
}

void Foo(int input)
    requires input < 0
{

}
```
