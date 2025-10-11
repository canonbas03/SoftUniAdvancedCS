using System.Collections;

namespace StackIterator
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _arr;
        public int Count { get; private set; }

        public Stack()
        {
            this._arr = new T[4];
        }

        public T Pop()
        {
            if (this.Count == 0)
                throw new IndexOutOfRangeException("No elements");

            T element = this._arr[--this.Count];
            this._arr[this.Count] = default;
            return element;
        }
        public void Push(T element)
        {
            if (this.Count == this._arr.Length)
                Grow();

            this._arr[this.Count++] = element;
        }

        private void Grow()
        {
            T[] newArray = new T[_arr.Length * 2];
            Array.Copy(this._arr, newArray, this._arr.Length);
            this._arr = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(this._arr, this.Count);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class StackEnumerator : IEnumerator<T>
        {
            private readonly T[] _arr;
            private readonly int _count;

            private int _index;

            public StackEnumerator(T[] array, int count)
            {
                this._arr=array;
                this._count = count;

                Reset();
            }

            public T Current => this._arr[_index];

            object IEnumerator.Current => this.Current;



            public bool MoveNext()
            {
                if(this._index < 0) return false;

                return --this._index >= 0;
            }

            public void Reset()
            {
                this._index = this._count;
            }

            public void Dispose()
            {
            }
        }
    }
}
