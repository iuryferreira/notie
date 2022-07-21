using System;

namespace Notie.Exceptions;

/// <summary>
///     The exception is thrown when a null notification is passed to the method that does not allow this operation.
/// </summary>
public class NotificationIsNullException : ArgumentNullException
{
    private new const string Message = "Notification cannot be null.";

    /// <summary>
    ///     Initialize a new instance of NotificationIsNullException with default message.
    /// </summary>
    public NotificationIsNullException () : base(Message) { }
}
