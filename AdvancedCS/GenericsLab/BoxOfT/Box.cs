namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;

        public int Count => this.list.Count;
        public Box()
        {
            list = new List<T>();
        }
        public void Add(T element)
        {
            this.list.Add(element);
        }

        public T Remove()
        {
            if(list.Count <= 0)
            {
                throw new ArgumentOutOfRangeException("No more elements!!!");
            }
            T element = this.list[list.Count - 1];
            this.list.RemoveAt(list.Count - 1);
            return element;

        }
    }
}
