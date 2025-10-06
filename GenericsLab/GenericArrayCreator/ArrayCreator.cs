namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int size, T element)
        {
            T[] array = new T[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = element;
            }
            return array;
        }
    }
}