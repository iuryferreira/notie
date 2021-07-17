using System.Collections.Generic;
using FluentValidation.Results;
using Notie.Models;

namespace Notie.Contracts
{
    /// <summary>
    ///     The Notifier interface.
    ///     Is responsible for defining what actions a validator should contain.
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// Add a notification to the notification list.
        /// </summary>
        /// <param name="notification"></param>
        /// <exception cref="Notie.Exceptions.NotificationIsNullException">The exception is thrown when a null
        /// notification is passed to the method that does not allow this operation.</exception>
        void AddNotification (Notification notification);

        /// <summary>
        /// Inserts or rewrites a list of notifications in the existing list.
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="overwrite"></param>
        /// <exception cref="Notie.Exceptions.NotificationIsNullException">The exception is thrown when a null
        /// notification is passed to the method that does not allow this operation.</exception>
        void AddNotifications (IEnumerable<Notification> notifications, bool overwrite = false);

        /// <summary>
        /// Inserts notifications from a FluentValidation validation.
        /// </summary>
        /// <param name="validationResult"></param>
        /// <exception cref="Notie.Exceptions.ValidationResultIsNullException">The exception is thrown when a null
        /// validation is passed to the method that does not allow this operation.</exception>
        void AddNotificationsByFluent (ValidationResult validationResult);

        /// <summary>
        ///     Defines the type of notification.
        /// </summary>
        /// <param name="type"></param>
        /// <exception cref="Exceptions.NotificationTypeIsNullException">
        ///     The exception is thrown when a null
        ///     type is passed to the method that does not allow this operation.
        /// </exception>
        void SetNotificationType (string type);

        /// <summary>
        ///     Remove all notifications.
        /// </summary>
        void Clear ();
    }
}
