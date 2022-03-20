namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
public class RequiresAttribute : Attribute
{
    public RequiresAttribute(string condition)
    {
        Condition = condition;
    }

    public string Condition { get; }
}

