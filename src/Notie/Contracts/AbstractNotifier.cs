using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Notie.Models;

namespace Notie.Contracts;

/// <summary>
///     The Notificator abstract class.
///     Contains all methods and fields for performing notification functions.
/// </summary>
public abstract class AbstractNotifier : INotifier
{
    private protected readonly List<Notification> Notifications = new();

    public abstract void AddNotification (Notification notification);
    public abstract void AddNotifications (IEnumerable<Notification> notifications, bool overwrite = false);
    public abstract void AddNotificationsByFluent (ValidationResult validationResult, bool overwrite = false);
    public abstract IReadOnlyCollection<Notification> All ();
    public abstract IReadOnlyCollection<Notification> GetByKey (string key);
    public abstract IReadOnlyCollection<Notification> GetByMessage (string message);
    public abstract IReadOnlyCollection<Notification> GetBy (Func<Notification, bool> condition);
    public abstract bool Any (Func<Notification, bool> condition);
    public abstract bool HasNotifications ();
    public abstract void Clear ();
}
