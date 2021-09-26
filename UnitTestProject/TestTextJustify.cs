using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AccertiveChallange;
namespace UnitTestProject
{
    [TestClass]
    public class TestTextJustify
    {
        [TestMethod]
        public void TestMethod1()
        {

            string actual = TextJustification.Justify("The quick brown fox jumps over the lazy dog.", 52);
            Assert.AreEqual("The-quick-brown-fox-jumps-over-the-lazy-dog.--------",actual);
        }
    
    }
}
