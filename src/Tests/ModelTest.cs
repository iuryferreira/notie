using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notie.Models;

namespace Tests
{
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void Notification_Constructor_Must_Define_the_Key_and_Message ()
        {
            Notification notification = new("any_key", "any_message");
            Assert.AreEqual(notification.Key, "any_key");
            Assert.AreEqual(notification.Message, "any_message");
        }

        [TestMethod]
        public void NotificationType_Constructor_Must_Define_the_Name ()
        {
            NotificationType notification = new("any_name");
            Assert.AreEqual(notification.Name, "any_name");
        }
    }
}
