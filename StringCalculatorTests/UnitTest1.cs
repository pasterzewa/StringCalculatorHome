using Microsoft.VisualStudio.TestTools.UnitTesting;
using stringCalculator;
using System;
using System.IO;

namespace StringCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 0;

            int result = calc.Add("");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 1;

            int result = calc.Add("1");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 3;

            int result = calc.Add("1,2");
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class UnitTests2
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("1,2,3");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 10;

            int result = calc.Add("1,2,3,4");
            Assert.AreEqual(expected, result);
        }
    }
    [TestClass]
    public class UnitTests3
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 3;

            int result = calc.Add("1\n2");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("1\n2,3");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("1,2\n3");
            Assert.AreEqual(expected, result);
        }
    }
    [TestClass]
    public class UnitTests4
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 3;

            int result = calc.Add("//;\n1;2");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("//;\n1;2;3");
            Assert.AreEqual(expected, result);
        }
    }
    [TestClass]
    public class UnitTests5
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed -1")]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            calc.Add("-1,2");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed -3")]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            calc.Add("1,2,-3");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed -2")]
        public void TestMethod3()
        {
            StringCalculator calc = new StringCalculator();
            calc.Add("1\n-2");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "negatives not allowed -1 -2")]
        public void TestMethod4()
        {
            StringCalculator calc = new StringCalculator();
            calc.Add("-1,-2");
        }
    }
    [TestClass]
    public class UnitTests6
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 2;

            int result = calc.Add("2,1001");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 1002;

            int result = calc.Add("2,1000");
            Assert.AreEqual(expected, result);
        }
    }
    [TestClass]
    public class UnitTests7
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 3;

            int result = calc.Add("//[;;]\n1;;2");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("//[;;;]\n1;;;2;;;3");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("//[***]\n1***2***3");
            Assert.AreEqual(expected, result);
        }
    }
    [TestClass]
    public class UnitTests8
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 6;

            int result = calc.Add("//[;;;][abb]\n1;;;2abb3");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            StringCalculator calc = new StringCalculator();
            int expected = 9;

            int result = calc.Add("//[***][;;][::::]\n1::::2***3;;2***1");
            Assert.AreEqual(expected, result);
        }
    }
}
