# Code Contracts (Experiment)

A set of attributes that enable compile-time code contracts with preconditions and postconditions to methods and properties.

They are meant to be analyzed at compile-time or as part of the development experience in an IDE.

The approach is similar to that of Nullable Reference Types.

Analyzer not produced as of yet.

Sample and language syntax proposal below.

## Attributes

* **RequiresAttribute** - Represents a precondition applied to a method parameter or property setter.
* **EnsuresAttribute** - Represents a postcondition applied to the return value of a method or a property getter.
* **ThrowsAttribute** - Indicates that the method may throw one or more specific exceptions.

## Details
The information will flow through the program as part of code analysis process.

A local variable that contains the result of a method with contract “ensures” would inherit that information.

This can be expanded to target other elements in code, like fields and generic parameters.
### Questions
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
[return: Ensures("> 0")]
int DoSomething([Requires(">= 0"), Requires("< 42")]  int arg)
{
    if(arg == 10)
    {
        throw new InvalidOperationException();
    }
    return arg;
}

void Foo([Requires("< 0")] int input)
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
