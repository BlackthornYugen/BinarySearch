using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSA1SortedArray;
using NUnit.Framework;

namespace SortedArrayTests
{

    public class SATestSuite01
    {
        [TestCase("B", 0)]
        [TestCase("BD", 1)]
        [TestCase("BDC", 1)]
        [TestCase("BDCA", 0)]
        public void DivideTest(String s, int i)
        {
            var sa = new SortedArray<char>(4);
            char c = default(char);
            foreach (char t in s)
            {
                c = t;
                sa.Insert(c);
            }
            Assert.AreEqual(c, sa[i]);
        }


    }
}
