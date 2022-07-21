namespace Notie.Models;

/// <summary>
///     This class define Notification object.
///     <param name="Key">The validation key or field.</param>
///     <param name="Message">Validation message for entered key.</param>
/// </summary>
public record Notification (string Key, string Message);

/// <summary>
///     This class define Notification object.
///     <param name="Key">The validation key or field.</param>
///     <param name="Message">Validation message for entered key.</param>
///     <param name="Data">Extra data.</param>
/// </summary>
public record Notification<T> (string Key, string Message, T Data) : Notification(Key, Message);
