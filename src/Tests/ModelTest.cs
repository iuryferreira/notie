using Notie.Models;
using Xunit;

namespace Tests
{
    public class ModelTest
    {
        [Fact]
        public void Notification_Constructor_Must_Define_the_Key_and_Message ()
        {
            Notification notification = new("any_key", "any_message");
            Assert.Equal("any_key", notification.Key);
            Assert.Equal("any_message", notification.Message);
        }
    }
}
