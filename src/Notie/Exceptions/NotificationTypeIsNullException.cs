using System;

namespace Notie.Exceptions
{
    /// <summary>
    ///     The exception is thrown when a null notification type is passed to the method that does not allow this operation.
    /// </summary>
    public class NotificationTypeIsNullException : ArgumentNullException
    {
        private new const string Message = "Notification type cannot be null.";

        /// <summary>
        ///     Initialize a new instance of NotificationTypeIsNullException with default message.
        /// </summary>
        public NotificationTypeIsNullException () : base(Message) { }
    }
}
