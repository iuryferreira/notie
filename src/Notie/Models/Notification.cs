namespace Notie.Models;

/// <summary>
///     This class define Notification object.
///     <param name="Key">The validation key or field.</param>
///     <param name="Message">Validation message for entered key.</param>
/// </summary>
public class Notification
{
    /// <summary>
    ///     This class define Notification object.
    ///     <param name="key">The validation key or field.</param>
    ///     <param name="message">Validation message for entered key.</param>
    /// </summary>
    public Notification(string key, string message)
    {
        Key = key;
        Message = message;
    }

    public string Key { get; }
    public string Message { get; }

    public void Deconstruct(out string Key, out string Message)
    {
        Key = this.Key;
        Message = this.Message;
    }
}
