using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSA1SortedArray
{
    public class SortedArray<T>
    {
        private T[] _storedTypes;
        private int _pointer = 0;

        public SortedArray(int maxN)
        {
            _storedTypes = new T[maxN];
        }

        public T this[int index]
        {
            get { return _storedTypes[index]; }
        }

        public void Insert(T arg)
        {
            _storedTypes[_pointer++] = arg;
        }
    }
}
