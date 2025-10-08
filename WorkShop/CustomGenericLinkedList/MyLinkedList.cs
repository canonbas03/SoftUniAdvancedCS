
namespace CustomGenericLinkedList
{
    public class MyLinkedList<T>
    {

        private readonly MyLinkedListNode<T> _start, _end;
        private int _count;
        public int Count => _count;
        public MyLinkedList()
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

        public void RemoveFirst()
        {
            this.ValidateNotEmpty();
            this.RemoveBetween(_start, _start.Next.Next);
        }

        public void RemoveLast()
        {
            this.ValidateNotEmpty();
            this.RemoveBetween(_end.Prev.Prev, _end);
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
    }
}
