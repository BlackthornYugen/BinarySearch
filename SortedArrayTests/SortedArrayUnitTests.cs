/* SortedArrayUnitTests.cs
 * 
 * Revision History:
 * ID	Author	Date	Message
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-05 6:13:50 AM -05:00	Added tests for Player; 6/6 pass.
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-04 6:25:31 AM -05:00	Finished insert so that items are pushed back in array. SortedArrayUnitTests 16/16 pass. (PS: For some reason git wasn't tracking the sorted array unit tests previously)
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-04 6:00:32 AM -05:00	Binary Search 15/15 SortedArray 12/12
    John Steel <jsteel-cc@conestogac.on.ca>	2015-02-03 9:52:57 PM -05:00	10 of 12 tests pass and refactored binarysearch out of sorted array.
 */

using System;
using System.Globalization;
using System.Text;
using JSA1SortedArray;
using NUnit.Framework;

namespace SortedArrayTests
{

    public class SortedArrayUnitTests
    {
        /// <summary>
        /// Check to see that the last inserted char is at the specified index
        /// </summary>
        /// <param name="s">A string of chars to insert</param>
        /// <param name="i">The index to look for the last char</param>
        /// <param name="arraySize">The size of the array</param>
        [TestCase("B", 0, 4)]
        [TestCase("B", 0, 5)]
        [TestCase("BD", 1, 4)]
        [TestCase("BD", 1, 5)]
        [TestCase("BDC", 1, 4)]
        [TestCase("BDC", 1, 5)]
        [TestCase("BDCA", 0, 4)]
        [TestCase("BDCA", 0, 5)]
        public void SortPositionTest(String s, int i, int arraySize)
        {
            var sa = new SortedArray<char>(arraySize);
            char lastChar = ' ';
            foreach (char c in s)
            {
                sa.Insert(c);
                lastChar = c;
            }
            // http://confluence.jetbrains.com/display/ReSharper/Specify+a+culture+in+string+conversion+explicitly
            Assert.AreEqual(lastChar.ToString(CultureInfo.InvariantCulture), sa[i].ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Check to see that the entire string is sorted as expected.
        /// </summary>
        /// <param name="unsortedString">The array of chars to insert</param>
        /// <param name="expectedString">How the array of chars should be stored</param>
        /// <param name="arraySize">The max size of the array</param>
        [TestCase("B", "B", 4)]
        [TestCase("BD", "BD", 4)]
        [TestCase("BDC", "BCD", 4)]
        [TestCase("BDCA", "ABCD", 4)]
        [TestCase("B", "B", 5)]
        [TestCase("BD", "BD", 5)]
        [TestCase("BDC", "BCD", 5)]
        [TestCase("BDCA", "ABCD", 5)]
        public void SortFullTest(String unsortedString, String expectedString, int arraySize)
        {
            var sa = new SortedArray<char>(arraySize);
            foreach (char c in unsortedString)
            {
                sa.Insert(c);
            }
            
            StringBuilder sortedString = new StringBuilder("");
            for (int i = 0; i < unsortedString.Length; i++)
            {
                sortedString.Append(sa[i]);
            }

            Assert.AreEqual(sortedString.ToString(), expectedString);
        }

        /// <summary>
        /// Confirm that IsEmpty is true after construction.
        /// </summary>
        [Test]
        public void TestEmpty()
        {
            var sa = new SortedArray<string>(4);
            Assert.IsTrue(sa.IsEmpty(), "IsEmpty didn't return True after construction.");
        }

        /// <summary>
        /// Confirm that IsEmpty is false after construction
        /// </summary>
        [Test]
        public void TestNotEmpty()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert("One Thing");
            Assert.IsFalse(sa.IsEmpty(), "IsEmpty returned True after insert.");
        }

        /// <summary>
        /// Confirm that isEmpty is false after filling the array.
        /// </summary>
        [Test]
        public void TestFull()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert("One Thing");
            sa.Insert("Two Thing");
            sa.Insert("Three Thing");
            sa.Insert("Four Thing");
            Assert.IsFalse(sa.IsEmpty(), "IsEmpty returned True after insert.");
        }

        /// <summary>
        /// Confirm that an exception is thrown when trying to insert into a full array.
        /// </summary>
        [Test]
        public void TestCantInsertTooMany()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert("One Thing");
            sa.Insert("Two Thing");
            sa.Insert("Three Thing");
            sa.Insert("Four Thing");
            // TODO: Throw a different or new exception? 
            Assert.Throws<IndexOutOfRangeException>(() => sa.Insert("Five Thing"));
        }

        /// <summary>
        /// Confirm that an exception is thrown when trying to insert a null value.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullInsert()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert(null);
        }

        /// <summary>
        /// Confirm that a positve int can be inserted.
        /// </summary>
        [Test]
        public void TestIntOne()
        {
            var sa = new SortedArray<int>(4);
            sa.Insert(1);
        }

        /// <summary>
        /// Confirm that a negative int can be inserted
        /// </summary>
        [Test]
        public void TestIntNegativeOne()
        {
            var sa = new SortedArray<int>(4);
            sa.Insert(-1);
        }

        /// <summary>
        /// Confirm that a zero can be inserted.
        /// </summary>
        [Test]
        public void TestIntZero()
        {
            var sa = new SortedArray<int>(4);
            sa.Insert(0);
        }
    }
}
