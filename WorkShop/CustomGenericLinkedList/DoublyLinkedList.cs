
namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {

        private readonly MyLinkedListNode<T> _start, _end;
        private int _count;
        public int Count => _count;
        public DoublyLinkedList()
        {
            _start = new MyLinkedListNode<T>(default);
            _end = new MyLinkedListNode<T>(default);

            _start.Next = _end;
            _end.Prev = _start;
        }

        public void AddFirst(T value)
        {
            this.InsertBetween(this._start, this._start.Next, value);
        }

        public void AddLast(T value)
        {
            this.InsertBetween(this._end.Prev, this._end, value);
        }

        public T GetFirst()
        {
            this.ValidateNotEmpty();
            return _start.Next.Value;
        }

        public T GetLast()
        {
            this.ValidateNotEmpty();
            return _end.Prev.Value;
        }

        public T RemoveFirst()
        {
            this.ValidateNotEmpty();
            var nodeToRemove = _start.Next;
            this.RemoveBetween(_start, _start.Next.Next);
            return nodeToRemove.Value;
        }

        public T RemoveLast()
        {
            this.ValidateNotEmpty();
            var nodeToRemove = _end.Prev;
            this.RemoveBetween(_end.Prev.Prev, _end);
            return nodeToRemove.Value;
        }

        private void ValidateNotEmpty()
        {
            if (this._count == 0)
                throw new InvalidOperationException("The linked list is empty!!!");
        }

        private void InsertBetween(MyLinkedListNode<T> a, MyLinkedListNode<T> b, T value)
        {
            MyLinkedListNode<T> newNode = new MyLinkedListNode<T>(value);
            a.Next = newNode;
            newNode.Next = b;
            b.Prev = newNode;
            newNode.Prev = a;

            _count++;
        }

        private void RemoveBetween(MyLinkedListNode<T> a, MyLinkedListNode<T> b)
        {
            a.Next.Prev = null;
            b.Prev.Next = null;

            a.Next = b;
            b.Prev = a;

            this._count--;
        }

        public void ForEach(Action<T> action)
        {
            var current = _start.Next;
            while (current != _end)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            //ValidateNotEmpty();
            T[] array = new T[_count];
            var current = _start.Next;
            int index = 0;

            while (current != _end)
            {
                array[index] = current.Value; 
                current = current.Next;
                index++;
            }
            return array;
        }
    }
}
