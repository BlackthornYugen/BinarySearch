using System;
using System.Globalization;
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
        [TestCase("B", 0)]
        [TestCase("BD", 1)]
        [TestCase("BDC", 1)]
        [TestCase("BDCA", 0)]
        public void SortPositionTest(String s, int i)
        {
            var sa = new SortedArray<char>(4);
            char c = default(char);
            foreach (char t in s)
            {
                c = t;
                sa.Insert(c);
            }
            // http://confluence.jetbrains.com/display/ReSharper/Specify+a+culture+in+string+conversion+explicitly
            Assert.AreEqual(c.ToString(CultureInfo.InvariantCulture), sa[i].ToString(CultureInfo.InvariantCulture));
        }

        [Test]
        public void TestEmpty()
        {
            var sa = new SortedArray<string>(4);
            Assert.IsTrue(sa.IsEmpty(), "IsEmpty didn't return True after construction.");
        }

        [Test]
        public void TestNotEmpty()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert("One Thing");
            Assert.IsFalse(sa.IsEmpty(), "IsEmpty returned True after insert.");
        }

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

        [Test]
        public void TestCantInsertTooMany()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert("One Thing");
            sa.Insert("Two Thing");
            sa.Insert("Three Thing");
            sa.Insert("Four Thing");
            // TODO: Throw different or new exception? 
            Assert.Throws<IndexOutOfRangeException>(() => sa.Insert("Five Thing"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullInsert()
        {
            var sa = new SortedArray<string>(4);
            sa.Insert(null);
        }

        [Test]
        public void TestIntOne()
        {
            var sa = new SortedArray<int>(4);
            sa.Insert(1);
        }

        [Test]
        public void TestIntNegativeOne()
        {
            var sa = new SortedArray<int>(4);
            sa.Insert(1);
        }

        [Test]
        public void TestIntZero()
        {
            var sa = new SortedArray<int>(4);
            sa.Insert(0);
        }
    }
}
