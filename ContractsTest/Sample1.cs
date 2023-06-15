public class Sample1 
{
    public void Do() 
    {
        // Satisfies Length 3
        string str = "FOO";
    }

    /*
    void Print([Requires("input.Length > 0"), Requires("input.Length < 50")] string input) 
    //  requires input.Length > 0
    //  requires input.Length < 50
    {
        Console.WriteLine(input);
    }
    */
}

/*
    class File
    {
        public string FileName 
        {
            [return: Ensures("return.Length =< 50")]
            get;
        } = null!;
    }
*/