namespace Functions.Monads
{
    public class Identity<T>
    {
        public Identity(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}