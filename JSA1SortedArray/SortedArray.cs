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
        private IComparable<T>[] _storedTypes;
        private int _tail;

        public SortedArray(int maxN)
        {
            _storedTypes = new IComparable<T>[maxN];
        }

        public T this[int index]
        {
            get
            {
                if (_storedTypes[index] == null) return default(T);
                return (T)_storedTypes[index];
            }
        }

        public void Insert(T arg)
        {
            if (null == arg)
                throw new ArgumentNullException("arg");
            if (IsEmpty())
            {
                _storedTypes[0] = (IComparable<T>) arg;
            }
            else
            {
                int insertPosition = _storedTypes.BinaryLocate((IComparable<T>)arg, _tail);
                if (insertPosition < 0) {insertPosition = _tail;}
                for (int i = _tail; i > insertPosition; i--)
                    _storedTypes[i] = _storedTypes[i - 1];
                _storedTypes[insertPosition] = (IComparable<T>)arg;                
            }
            _tail++;
        }

        public bool IsEmpty()
        {
            return _tail == 0;
        }
    }
}
