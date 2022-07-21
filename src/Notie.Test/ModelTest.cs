using Notie.Models;
using Xunit;

namespace Notie.Test;

public class ModelTest
{
    [Fact]
    public void Notification_Constructor_Must_Define_the_Key_and_Message ()
    {
        Notification notification = new("any_key", "any_message");
        Assert.Equal("any_key", notification.Key);
        Assert.Equal("any_message", notification.Message);
    }
    [Fact]
    public void Notification_Constructor_Must_Define_the_Key_Message_And_Data ()
    {
        var notification = new Notification<string>("any_key", "any_message", "");
        Assert.Equal("any_key", notification.Key);
        Assert.Equal("any_message", notification.Message);
        Assert.Equal("", notification.Data);
    }
}
