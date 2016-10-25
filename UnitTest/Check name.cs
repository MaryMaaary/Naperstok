using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication2;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckName()
        {
            MyGlass classic = new MyGlass(2);
            Assert.AreEqual("Name", classic.getname(""));
        }
    }
}
