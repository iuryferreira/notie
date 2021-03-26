using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Notie.Models;

namespace Notie.Contracts
{
    /// <summary>
    /// The Notificator abstract class.
    /// Contains all methods and fields for performing notification functions.
    /// </summary>
    /// <remarks>
    /// <para>This abstract class defines behaviors and query fields for adding notifications.</para>
    /// </remarks>
    public abstract class AbstractNotificator : INotificator
    {
        private protected readonly List<Notification> _notifications;

        protected AbstractNotificator ()
        {
            _notifications = new();
            NotificationType = new("Default");
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotifications => _notifications.Any();
        public NotificationType NotificationType { get; private protected set; }

        public abstract void AddNotification (Notification notification);
        public abstract void AddNotifications (IEnumerable<Notification> notifications, bool overwrite = false);
        public abstract void AddNotificationsByFluent (ValidationResult validationResult);
        public abstract void SetNotificationType (NotificationType type);
        public abstract void Clear ();
    }
}
