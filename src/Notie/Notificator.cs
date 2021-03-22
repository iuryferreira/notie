using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Notie.Contracts;
using Notie.Exceptions;
using Notie.Models;

namespace Notie
{
    /// <summary>
    /// The Notificator class.
    /// Contains all methods and fields for performing notification functions.
    /// </summary>
    /// <remarks>
    /// <para>This class execute behaviors for handle notifications.</para>
    /// </remarks>
    public class Notificator : AbstractNotificator
    {
        public override void AddNotification (Notification notification)
        {
            if (notification is null)
            {
                throw new NotificationIsNullException();
            }

            _notifications.Add(notification);
        }

        public override void AddNotifications (IEnumerable<Notification> notifications, bool overwrite = false)
        {
            try
            {
                if (overwrite)
                {
                    _notifications.Clear();
                }

                _notifications?.AddRange(notifications);
            }
            catch (ArgumentNullException)
            {
                throw new NotificationIsNullException();
            }
        }

        public override void AddNotificationsByFluent (ValidationResult validationResult)
        {
            if (validationResult is null)
            {
                throw new ValidationResultIsNullException();
            }

            _notifications.Clear();
            foreach (var error in validationResult.Errors)
            {
                var notification = new Notification(
                    error.PropertyName[(error.PropertyName.IndexOf('.') + 1)..],
                    error.ErrorMessage);
                AddNotification(notification);
            }
        }

        public override void SetNotificationType (NotificationType type)
        {
            NotificationType = type ?? throw new NotificationTypeIsNullException();
        }
    }
}
