using System.Security.Cryptography.X509Certificates;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> _list;
        private int _index;
        public ListyIterator(List<T> list)
        {
            this._list = list;
        }

        public bool Move()
        {
            if (!this.HasNext()) return false;

            this._index++;
            return true;
        }
        public bool HasNext() => this.IndexIsValid(this._index + 1);

        public T Print()
        {
            if (!this.IndexIsValid(this._index)) throw new InvalidOperationException("Invalid Operation!");

            return this._list[this._index];
        }

        private bool IndexIsValid(int index)
        {
            return index < this._list.Count;
        }
    }
}
/*
Create Steve George
HasNext
Print
Move
Print
END
 */