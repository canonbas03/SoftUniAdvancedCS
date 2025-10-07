namespace GenericSwapMethod
{

    public class Box<T>
    {
        private readonly T _value;

        public T Value => _value;

        public Box(T value)
        {
            this._value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {Value}";
        }
    }

}
