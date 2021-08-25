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
        ///     Add a notification to the notification list.
        /// </summary>
        /// <param name="notification">Non-null notification to be inserted into the notifier.</param>
        /// <exception cref="Exceptions.NotificationIsNullException">
        ///     The exception is thrown when a null
        ///     notification is passed to the method that does not allow this operation.
        /// </exception>
        void AddNotification (Notification notification);

        /// <summary>
        ///     Inserts or rewrites a list of notifications in the existing list.
        /// </summary>
        /// <param name="notifications">Non-null list of notifications to be inserted into the notifier.</param>
        /// <param name="overwrite">If true, it overwrites all notifications that already exist in the notifier.</param>
        /// <exception cref="Exceptions.NotificationIsNullException">
        ///     The exception is thrown when a null
        ///     notification is passed to the method that does not allow this operation.
        /// </exception>
        void AddNotifications (IEnumerable<Notification> notifications, bool overwrite = false);

        /// <summary>
        ///     Inserts notifications from a FluentValidation validation.
        /// </summary>
        /// <param name="validationResult">Non-null result of a FluentValidation validator.</param>
        /// /// <param name="overwrite">If true, it overwrites all notifications that already exist in the notifier.</param>
        /// <exception cref="Exceptions.ValidationResultIsNullException">
        ///     The exception is thrown when a null
        ///     validation is passed to the method that does not allow this operation.
        /// </exception>
        void AddNotificationsByFluent (ValidationResult validationResult, bool overwrite = false);

        /// <summary>
        ///     Defines the type of notification.
        /// </summary>
        /// <param name="type">A name for the type of notifications you are handling.</param>
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
