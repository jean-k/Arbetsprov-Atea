using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Message_Console_Application;

namespace UnitTestProjectMessages
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HandleMessages hm = new HandleMessages();
            MessageInfo mi = new MessageInfo();
            mi.Message = "Message to website";
            mi.Date = DateTime.Now;
            hm.SaveMessage("Message to website");

            Assert.AreEqual();
        }
    }
}
