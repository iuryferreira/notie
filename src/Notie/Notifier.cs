using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Notie.Contracts;
using Notie.Exceptions;
using Notie.Models;

namespace Notie;

/// <summary>
///     The Notificator class.
///     Contains all methods and fields for performing notification functions.
/// </summary>
/// <remarks>
///     <para>This class execute behaviors for handle notifications.</para>
/// </remarks>
public class Notifier : AbstractNotifier
{
    public override void AddNotification (Notification notification)
    {
        if (notification is null)
        {
            throw new NotificationIsNullException();
        }

        Notifications.Add(notification);
    }

    public override void AddNotifications(IEnumerable<Notification> notifications, bool overwrite = false)
    {
        if (notifications == null)
        {
            throw new NotificationIsNullException();
        }

        if (overwrite)
        {
            Notifications.Clear();
        }

        Notifications.AddRange(notifications);
    }

    public override void AddNotificationsByFluent (ValidationResult validationResult, bool overwrite = false)
    {
        if (validationResult is null)
        {
            throw new ValidationResultIsNullException();
        }

        if (overwrite)
        {
            Notifications.Clear();
        }

        foreach (var error in validationResult.Errors)
        {
            int startIndex = error.PropertyName.IndexOf('.') + 1;
            string propertyName = error.PropertyName.Substring(startIndex);
            var notification = new Notification(propertyName, error.ErrorMessage);
            AddNotification(notification);
        }
    }

    public override IReadOnlyCollection<Notification> All () => Notifications;

    public override IReadOnlyCollection<Notification> GetByKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException($"'{nameof(key)}' cannot be null or empty.");
        }
        return Notifications.Where(notification => notification.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }

    public override IReadOnlyCollection<Notification> GetByMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentException($"'{nameof(message)}' cannot be null or empty.");
        }
        return Notifications.Where(notification => notification.Message.Equals(message, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }

    public override IReadOnlyCollection<Notification> GetBy (Func<Notification, bool> condition)
    {
        if (condition is null) throw new ArgumentException($"'{nameof(condition)}' cannot be null.");
        var result = Notifications.Where(condition).ToList();
        return result.Count.Equals(0) ? null : result;
    }

    public override bool Any (Func<Notification, bool> condition)
    {
        if (condition is null) throw new ArgumentException($"'{nameof(condition)}' cannot be null.");
        return Notifications.Any(condition);
    }

    public override bool HasNotifications () => Notifications.Any();

    public override void Clear () => Notifications.Clear();
}
