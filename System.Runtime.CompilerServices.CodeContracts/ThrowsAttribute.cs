namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public class ThrowsAttribute : Attribute
{
    public ThrowsAttribute(params Type[] exceptionTypes)
    {
        ExceptionTypes = exceptionTypes;
    }

    public Type[] ExceptionTypes { get; }
}

