# Code Contracts (Experiment)

A set of attributes that enable compile-time code contracts with preconditions and postconditions to methods and properties.

They are meant to be analyzed at compile-time or as part of the development experience in an IDE.

Analyzer not produced as of yet.

## Attributes
* **RequiresAttribute** - Represents a precondition applied to a method parameter or property setter.
* **EnsuresAttribute** - Represents a postcondition applied to the return value of a method or a property getter.
* **ThrowsAttribute** - Indicates that the method may throw one or more specific exceptions.

## Sample
From ContractsTest project:

```c#
// CS1234: Argument does not satisfy requirement: arg < 42
// CS1235: InvalidOperationException is unchecked.
var result = DoSomething(42);

// "result" is marked as satisfying > 0

// CS1234: Argument does not satisfy requirement: input < 0
Foo(result);

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
``