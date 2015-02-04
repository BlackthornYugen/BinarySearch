using System;
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
            get { return (T)_storedTypes[index]; }
        }

        private int BinarySearch(IComparable<T> arg)
        {
            int low = 0;
            int high = _tail;

            while (low < high)
            {
                int midpoint = (high - low) / 2 + low;
                int compareResult = _storedTypes[midpoint].CompareTo((T) arg);

                if (compareResult > 0)
                    low = midpoint + 1;
                else
                    high = midpoint;
            }

            if ((low == high) && (arg == _storedTypes[low]))
                return low;
            return -1;
        }

        public void Insert(T arg)
        {
            if (null == arg)
                throw new ArgumentNullException("arg");
            if (IsEmpty())
                _storedTypes[0] = (IComparable<T>) arg;
            else
                _storedTypes[BinarySearch((IComparable<T>) arg)] = (IComparable<T>)arg;
            _tail++;
        }

        public bool IsEmpty()
        {
            return _tail == 0;
        }
    }
}
