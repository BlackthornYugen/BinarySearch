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
        /// <returns>Returns the index of where the needle should be found.</returns>
        public static int BinarySearch(this IComparable[] haystack, IComparable needle, int high, int low = 0)
        {
            if (high > haystack.Length - 1 || high < 0 || low > high)
                throw new ArgumentOutOfRangeException("high", "High must be a positive int that is < haystack length and >= low.");
            if (low > haystack.Length - 1 || low < 0)
                throw new ArgumentOutOfRangeException("low", "Low must be a positive int that is < haystack length.");

            while (low < high)
            {
                int midpoint = (high - low) / 2 + low;
                int compareResult = haystack[midpoint].CompareTo(needle);

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
        /// <returns>Returns the index of where the needle should be found.</returns>
        public static int BinarySearch(this IComparable[] haystack, IComparable needle)
        {
            return haystack.BinarySearch(needle, haystack.Length - 1);
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
        public static int BinaryLocate(this IComparable[] haystack, IComparable needle, int high, int low = 0)
        {
            int index = BinarySearch(haystack, needle, high, low);
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
        public static int BinaryLocate(this IComparable[] haystack, IComparable needle)
        {
            return haystack.BinaryLocate(needle, haystack.Length - 1);
        }
    }
}
