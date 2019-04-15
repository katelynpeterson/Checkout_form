using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void validateName()
        {
            string customerFirstname = "John";
            Name firstname = new Name(customerFirstname);

            
        }
    }
}
