/* SortedArray.cs
 * A generic sorted array.
 * 
 * Revision History:
 * ID	Author	Date	Message
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-05 6:13:50 AM -05:00	Added tests for Player; 6/6 pass.
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-04 6:25:31 AM -05:00	Finished insert so that items are pushed back in array. SortedArrayUnitTests 16/16 pass. (PS: For some reason git wasn't tracking the sorted array unit tests previously)
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-04 6:00:32 AM -05:00	Binary Search 15/15 SortedArray 12/12
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-03 9:52:57 PM -05:00	10 of 12 tests pass and refactored binarysearch out of sorted array.
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-03 8:44:29 PM -05:00	7 of 11 tests pass
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-03 7:57:19 PM -05:00	2 of 4 tests pass
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-03 11:45:02 AM -05:00	Init
 */

using System;
using System.Collections.Generic;

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
