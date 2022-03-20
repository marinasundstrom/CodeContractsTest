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