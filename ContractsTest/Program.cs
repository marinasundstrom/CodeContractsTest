// CS1234: Argument does not satisfy requirement: arg < 42
// CS1235: InvalidOperationException is unchecked.
var result = DoSomething(42);

// "result" is marked as satisfying > 0

// CS1234: Argument does not satisfy requirement: input < 0
Foo(result);

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

void Foo([Requires("{input} < 0")] int input)
{

}

void Print([Requires("{input}.Length > 0"), Requires("{input}.Length < 50")] string input) 
//  requires input.Length > 0
//  requires input.Length < 50
{
    Console.WriteLine(input);
}

class File 
{
    public string FileName 
    {
        [return: Ensures("return.Length =< 50")]
        get;
    } = null!;
}