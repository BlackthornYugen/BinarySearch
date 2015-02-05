/* BinarySearchUnitTests.cs
 * The unit tests for the Binary Search methods
 * 
 * Revision History: 
 * ID	Author	Date	Message
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-05 6:13:50 AM -05:00	Added tests for Player; 6/6 pass.
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-04 6:25:31 AM -05:00	Finished insert so that items are pushed back in array. SortedArrayUnitTests 16/16 pass. (PS: For some reason git wasn't tracking the sorted array unit tests previously)
 */

using System;
using JSA1SortedArray;
using NUnit.Framework;

namespace SortedArrayTests
{
    class BinarySearchUnitTests
    {
        [TestCase(0, 'A')]
        [TestCase(-1, 'B')]
        [TestCase(1, 'C')]
        [TestCase(-1, 'D')]
        [TestCase(2, 'E')]
        [TestCase(3, 'F')]
        [TestCase(4, 'Z')]
        public void CheckIndecies(int i, char c)
        {
            var comparables = new IComparable[] { 'A', 'C', 'E', 'F', 'Z' };
            Assert.AreEqual(i, comparables.BinaryLocate(c));
        }

        [TestCase(0, 'A', 0)]
        [TestCase(-1, 'B', 3)]
        [TestCase(1, 'C', -1, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 'C', 6, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(-1, 'D', 100, ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, 'E', 2)]
        [TestCase(-1, 'F', 2)]
        [TestCase(-1, 'Z', 3)]
        public void CheckIndecies(int i, char c, int high)
        {
            var comparables = new IComparable[] { 'A', 'C', 'E', 'F', 'Z' };
            Assert.AreEqual(i, comparables.BinaryLocate(c, high));
        }
    }
}
