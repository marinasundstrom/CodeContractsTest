namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.ReturnValue, AllowMultiple = true)]
public class EnsuresAttribute : Attribute
{
    public EnsuresAttribute(string condition)
    {
        Condition = condition;
    }

    public string Condition { get; }
}

