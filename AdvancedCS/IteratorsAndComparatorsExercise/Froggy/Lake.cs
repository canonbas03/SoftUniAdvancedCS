using System.Collections;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly int[] _stones;

        public Lake(int[] stones)
        {
            this._stones = stones;
        }
        public IEnumerator<int> GetEnumerator() => new LakeEnumerator(this._stones);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        private class LakeEnumerator : IEnumerator<int>
        {
            private readonly int[] _stones;
            private int _index;
            private bool _forward;

            public LakeEnumerator(int[] stones)
            {
                this._stones = stones;
                Reset();
            }
            public int Current => this._stones[this._index];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (IsTerminated()) return false;

                if (_forward)
                {
                    this._index += 2;

                    if (_index >= _stones.Length)
                    {
                        _forward = false;
                        _index = _stones.Length - (_stones.Length % 2) - 1;
                    }

                }
                else
                {
                    this._index -= 2;
                }

                return !IsTerminated();
            }

            public void Reset()
            {
                this._index = -2;
                _forward = true;
            }
            public void Dispose()
            {
            }

            private bool IsTerminated() => this._index == -1;
        }
    }
}
