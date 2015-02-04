using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSA1SortedArray
{
    public static class Toolbox
    {
        /// <summary>
        /// Perform a binary search on any sorted array of comparable objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="haystack">A sorted array of icomparable objects</param>
        /// <param name="needle">The icomparable object to locate</param>
        /// <param name="high">The highest index to search.</param>
        /// <param name="low">The lowest index to search.</param>
        /// <returns>Returns the index of needle or -1 if not found.</returns>
        public static int BinarySearch<T>(this IComparable<T>[] haystack, IComparable<T> needle, int high, int low = 0)
        {
            while (low < high)
            {
                int midpoint = (high - low) / 2 + low;
                int compareResult = haystack[midpoint].CompareTo((T) needle);

                if (compareResult > 0)
                    low = midpoint + 1;
                else
                    high = midpoint;
            }

            if ((low == high) && (needle == haystack[low]))
                return low;
            return -1;
        }

        /// <summary>
        /// Perform a binary search on any sorted array of comparable objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="haystack">A sorted array of icomparable objects</param>
        /// <param name="needle">The icomparable object to locate</param>
        /// <returns>Returns the index of needle or -1 if not found.</returns>
        public static int BinarySearch<T>(this IComparable<T>[] haystack, IComparable<T> needle)
        {
            return haystack.BinarySearch(needle, haystack.Length - 1);
        }

    }
}
