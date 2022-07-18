namespace FP;

public sealed class Either<TLeft, TRight>
{
    private TLeft _left;
    private TRight _right;
    public readonly bool IsLeft;

    public TLeft Left 
    {
        private set => _left = value;
        get
        {
            if (IsLeft == false)
                throw new ArgumentException();
            
            return _left;
        }
    }

    public TRight Right 
    {
         private set => _right = value;
         get
         {
            if (IsLeft)
                throw new ArgumentException();

            return _right;
         }
    }

    private Either(TLeft left, TRight right, bool isLeft)
    {
        IsLeft = isLeft;
        Left = left;
        Right = right;
    }

    public static Either<TLeft,TRight> MakeLeft(TLeft left)
        => new Either<TLeft, TRight>(left, default, true);
    
    public static Either<TLeft,TRight> MakeRight(TRight right)
        => new Either<TLeft,TRight>(default, right, false);
}