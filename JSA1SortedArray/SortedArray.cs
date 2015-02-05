using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSA1SortedArray
{
    public class SortedArray<T>
    {
        private IComparable[] _storedTypes;
        private int _tail;

        public SortedArray(int maxN)
        {
            _storedTypes = new IComparable[maxN];
        }
        public bool IsEmpty()
        {
            return _tail == 0;
        }

        public T Find(T arg)
        {
            int searchResult = _storedTypes.BinaryLocate((IComparable) arg);
            if (searchResult < 0) throw new KeyNotFoundException();
            return (T)_storedTypes[searchResult];
        }

        public void Insert(T arg)
        {
            if (null == arg)
                throw new ArgumentNullException("arg");
            if(_tail == _storedTypes.Length)
                throw new IndexOutOfRangeException("Cannot insert because array is full.");
            if (IsEmpty())
            {
                _storedTypes[0] = (IComparable) arg;
            }
            else
            {
                int insertPosition = _storedTypes.BinarySearch((IComparable)arg, _tail);
                if (insertPosition < 0) {insertPosition = _tail;}
                for (int i = _tail; i > insertPosition; i--)
                    _storedTypes[i] = _storedTypes[i - 1];
                _storedTypes[insertPosition] = (IComparable)arg;                
            }
            _tail++;
        }

        public T this[int index]
        {
            get
            {
                if (_storedTypes[index] == null) return default(T);
                return (T)_storedTypes[index];
            }
        }
    }
}
