using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Program1.CheckParentheses("(+ 7 9 11)"), true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(Program1.CheckParentheses("(+ 7 9 11))"), false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(Program1.CheckParentheses("(60 * 9 / 5) + 32"), true);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(Program1.CheckParentheses("(60 * 9 / 5)) + 32"), false);
        }
    }
}
