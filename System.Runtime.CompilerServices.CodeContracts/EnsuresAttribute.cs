namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Field, AllowMultiple = true)]
public class EnsuresAttribute : Attribute
{
    public EnsuresAttribute(string condition)
    {
        Condition = condition;
    }

    public string Condition { get; }
}

