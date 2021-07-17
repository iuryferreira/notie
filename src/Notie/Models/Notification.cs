namespace Notie.Models
{
    /// <summary>
    ///     This class define Notification object.
    ///     <param name="Key">The validation key or field.</param>
    ///     <param name="Message">Validation message for entered key.</param>
    /// </summary>
    public record Notification (string Key, string Message);
}
