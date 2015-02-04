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
        /// <returns>Returns the index of needle or where the needle should go.</returns>
        public static int BinaryLocate<T>(this IComparable<T>[] haystack, IComparable<T> needle, int high, int low = 0)
        {
            if (high > haystack.Length - 1 || high < 0)
                throw new IndexOutOfRangeException("High must be a positive int that is smaller than haystack length.");
            if (low > haystack.Length - 1 || low < 0)
                throw new IndexOutOfRangeException("Low must be a positive int that is smaller than haystack length.");
            while (low < high)
            {
                int midpoint = (high - low) / 2 + low;
                int compareResult = haystack[midpoint].CompareTo((T) needle);

                if (compareResult < 0)
                    low = midpoint + 1;
                else
                    high = midpoint;
            }

            return low;
        }

        /// <summary>
        /// Perform a binary search on any sorted array of comparable objects.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="haystack">A sorted array of icomparable objects</param>
        /// <param name="needle">The icomparable object to locate</param>
        /// <returns>Returns the index of needle or -1 if not found.</returns>
        public static int BinaryLocate<T>(this IComparable<T>[] haystack, IComparable<T> needle)
        {
            return haystack.BinaryLocate(needle, haystack.Length - 1);
        }


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
            int index = BinaryLocate(haystack, needle, high, low);
            if (needle.Equals(haystack[index])) return index;
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
