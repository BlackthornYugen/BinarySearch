using System;
using System.Globalization;
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
            var comparables = new IComparable<char>[] { 'A', 'C', 'E', 'F', 'Z' };
            Assert.AreEqual(i, comparables.BinarySearch(c));
        }

        [TestCase(0, 'A', 0)]
        [TestCase(-1, 'B', 3)]
        [TestCase(1, 'C', -1, ExpectedException = typeof(IndexOutOfRangeException))]
        [TestCase(1, 'C', 6, ExpectedException = typeof(IndexOutOfRangeException))]
        [TestCase(-1, 'D', 100, ExpectedException = typeof(IndexOutOfRangeException))]
        [TestCase(2, 'E', 2)]
        [TestCase(-1, 'F', 2)]
        [TestCase(-1, 'Z', 3)]
        public void CheckIndecies(int i, char c, int high)
        {
            var comparables = new IComparable<char>[] { 'A', 'C', 'E', 'F', 'Z' };
            Assert.AreEqual(i, comparables.BinarySearch(c, high));
        }
    }
}
