using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Notie.Models;

namespace Notie.Contracts
{
    /// <summary>
    ///     The Notificator abstract class.
    ///     Contains all methods and fields for performing notification functions.
    /// </summary>
    public abstract class AbstractNotifier : INotifier
    {
        private protected readonly List<Notification> _notifications;

        protected AbstractNotifier ()
        {
            _notifications = new();
            NotificationType = "Default";
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();
        public string NotificationType { get; private protected set; }

        public abstract void AddNotification (Notification notification);
        public abstract void AddNotifications (IEnumerable<Notification> notifications, bool overwrite = false);
        public abstract void AddNotificationsByFluent (ValidationResult validationResult);
        public abstract void SetNotificationType (string type);
        public abstract void Clear ();
    }
}
