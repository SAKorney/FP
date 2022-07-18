namespace FP;

public sealed class Option<TValue> where TValue : IEquatable<TValue>
{
    private TValue _value;

    public bool IsAssigned { get; private set;}

    public TValue Value
    { 
        set => _value = value;

        get
        {
            if (false == IsAssigned)
                throw new ArgumentException();
            
            return _value;
        }
    }

    public Option(TValue value)
    {
        IsAssigned = (false == EqualityComparer<TValue>.Default.Equals(value, default));
        Value = value;
    }
}
