using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Notie;
using Notie.Contracts;
using Notie.Exceptions;
using Notie.Models;
using Xunit;

namespace Tests
{
    public class NotifierTest
    {
        private INotifier _sut;

        #region AddNotification

        [Fact(DisplayName = "01 - AddNotification must throw NotificationIsNullException if the notification to add is null")]
        public void AddNotification_MustThrowNotificationIsNullException_NotificationIsNull ()
        {
            _sut = new Notifier();
            Assert.Throws<NotificationIsNullException>(() => _sut.AddNotification(null));
        }

        #endregion

        #region AddNotifications

        [Fact(DisplayName = "02 - AddNotifications must throw NotificationIsNullException if the list of notifications to add is null")]
        public void AddNotifications_MustThrowNotificationIsNullException_NotificationsIsNull ()
        {
            _sut = new Notifier();
            Assert.Throws<NotificationIsNullException>(() => _sut.AddNotifications(null));
        }

        [Fact(DisplayName = "03 - AddNotifications should receive a list of notifications and include it with the others")]
        public void AddNotifications_ShouldReceiveNotifications_IncludeItWithOthers ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("any_key", "any_message"));
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            _sut.AddNotifications(notifications);
            Assert.Equal(3, _sut.All().Count);
        }

        [Fact(DisplayName = "04 - AddNotifications should overwrite the previous list if overwrite parameter is true")]
        public void AddNotifications_ShouldOverwritePreviousList_OverwriteParameterIsTrue ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("any_key", "any_message"));
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            _sut.AddNotifications(notifications, true);
            Assert.Equal(2, _sut.All().Count);
        }

        #endregion

        #region AddNotificationsByFluent

        [Fact(DisplayName = "05 - AddNotificationsByFluent must throw ValidationResultIsNullException if the ValidationResult to add is null")]
        public void AddNotificationsByFluent_MustThrowValidationResultIsNullException_ValidationResultIsNull ()
        {
            _sut = new Notifier();
            Assert.Throws<ValidationResultIsNullException>(() => _sut.AddNotificationsByFluent(null));
        }

        [Fact(DisplayName = "06 - AddNotificationsByFluent must receive ValidationResult and turn into notifications")]
        public void AddNotificationsByFluent_MustReceiveValidationResult_TurnIntoNotifications ()
        {
            _sut = new Notifier();
            ExampleEntity entity = new();
            var validator = new Validator();
            _sut.AddNotificationsByFluent(validator.Validate(entity));
            Assert.Equal(1, _sut.All().Count);
        }

        [Fact(DisplayName = "07 - AddNotificationsByFluent should overwrite the previous list if overwrite parameter is true")]
        public void AddNotificationsByFluent_ShouldOverwritePreviousList_OverwriteParameterIsTrue ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("any_key", "any_message"));
            ExampleEntity entity = new();
            var validator = new Validator();
            _sut.AddNotificationsByFluent(validator.Validate(entity), true);
            Assert.Equal(1, _sut.All().Count);
        }

        #endregion

        #region HasNotifications

        [Fact(DisplayName = "08 - HasNotifications must return false if no notification is added")]
        public void HasNotifications_MustReturnFalse_NoNotificationIsAdded ()
        {
            _sut = new Notifier();
            Assert.False(_sut.HasNotifications());
        }

        [Fact(DisplayName = "09 - HasNotifications must return true if any notification is added")]
        public void HasNotifications_MustReturnTrue_AnyNotificationIsAdded ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("any_key", "any_message"));
            Assert.True(_sut.HasNotifications());
        }

        #endregion

        #region Others

        [Fact(DisplayName = "10 - Clear should remove all notifications")]
        public void Clear_ShouldRemoveAllNotifications ()
        {
            _sut = new Notifier();
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            _sut.AddNotifications(notifications);
            _sut.Clear();
            Assert.False(_sut.HasNotifications());
        }

        #endregion

        #region GetByKey

        [Fact(DisplayName = "11 - GetByKey must throw ArgumentException if the key is null or empty")]
        public void GetByKey_MustThrowArgumentException_KeyIsNullOrEmpty ()
        {
            _sut = new Notifier();
            Assert.Throws<ArgumentException>(() => _sut.GetByKey(null));
        }

        [Fact(DisplayName = "12 - GetByKey should return a notification if the key exists")]
        public void GetByKey_ShouldReturnANotification_KeyExists ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("key", "value"));
            Assert.NotNull(_sut.GetByKey("key").First());
        }

        [Fact(DisplayName = "13 - GetByKey should return null if the key not exists")]
        public void GetByKey_ShouldReturnNull_KeyNotExists ()
        {
            _sut = new Notifier();
            Assert.Null(_sut.GetByKey("key"));
        }

        #endregion

        #region GetByMessage

        [Fact(DisplayName = "14 - GetByMessage must throw ArgumentException if the key is null or empty")]
        public void GetByMessage_MustThrowArgumentException_KeyIsNullOrEmpty ()
        {
            _sut = new Notifier();
            Assert.Throws<ArgumentException>(() => _sut.GetByMessage(null));
        }

        [Fact(DisplayName = "15 - GetByMessage should return a notification if the key exists")]
        public void GetByMessage_ShouldReturnANotification_KeyExists ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("key", "value"));
            Assert.NotNull(_sut.GetByMessage("value").First());
        }

        [Fact(DisplayName = "16 - GetByMessage should return null if the key not exists")]
        public void GetByMessage_ShouldReturnNull_KeyNotExists ()
        {
            _sut = new Notifier();
            Assert.Null(_sut.GetByMessage("value"));
        }

        #endregion

        #region GetBy

        [Fact(DisplayName = "17 - GetBy must throw ArgumentException if the key is null or empty")]
        public void GetBy_MustThrowArgumentException_KeyIsNullOrEmpty ()
        {
            _sut = new Notifier();
            Assert.Throws<ArgumentException>(() => _sut.GetBy(null));
        }

        [Fact(DisplayName = "18 - GetBy should return a notification if the key exists")]
        public void GetBy_ShouldReturnANotification_KeyExists ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("key", "value"));
            Assert.NotNull(_sut.GetBy(x => x.Key == "key").First());
        }

        [Fact(DisplayName = "19 - GetBy should return null if the key not exists")]
        public void GetBy_ShouldReturnNull_KeyNotExists ()
        {
            _sut = new Notifier();
            Assert.Null(_sut.GetBy(x => x.Key == "key"));
        }

        #endregion

        #region Any

        [Fact(DisplayName = "20 - Any must throw ArgumentException if the key is null or empty")]
        public void Any_MustThrowArgumentException_KeyIsNullOrEmpty ()
        {
            _sut = new Notifier();
            Assert.Throws<ArgumentException>(() => _sut.Any(null));
        }

        [Fact(DisplayName = "21 - Any should return true if the key exists")]
        public void Any_ShouldReturnANotification_KeyExists ()
        {
            _sut = new Notifier();
            _sut.AddNotification(new("key", "value"));
            var result = _sut.Any(x => x.Key == "key");
            Assert.True(result);
        }

        [Fact(DisplayName = "22 - Any should return false if the key not exists")]
        public void Any_ShouldReturnFalse_KeyNotExists ()
        {
            _sut = new Notifier();
            var result = _sut.Any(x => x.Key == "key");
            Assert.False(result);
        }

        #endregion

        #region Helpers

        private class ExampleEntity
        {
            public static string Field => "";
        }

        private class Validator : AbstractValidator<ExampleEntity>
        {
            public Validator ()
            {
                RuleFor(ex => ExampleEntity.Field).NotEmpty();
            }
        }

        #endregion

    }

    public class GenericNotifierTest
    {
        [Fact(DisplayName = "01 - AddNotification must throw NotificationIsNullException when notification is null")]
        public void AddNotification_ShouldThrowNotificationIsNullException_WhenNotificationIsNull ()
        {
            var sut = new Notifier<Notification>();
            Assert.Throws<NotificationIsNullException>(() => sut.AddNotification(null));
        }

        [Fact(DisplayName = "02 - AddNotification must add notification when notification is valid")]
        public void AddNotification_ShouldAddNotification_WhenNotificationIsValid ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            Assert.Equal(1, sut.All().Count);
        }

        [Fact(DisplayName = "03 - AddNotifications must throw NotificationIsNullException when notifications are null")]
        public void AddNotifications_ShouldThrowNotificationIsNullException_WhenNotificationsAreNull ()
        {
            var sut = new Notifier<Notification>();
            Assert.Throws<NotificationIsNullException>(() => sut.AddNotifications(null));
        }

        [Fact(DisplayName = "04 - AddNotifications must overwrite notifications when overwrite is true")]
        public void AddNotifications_ShouldOverwriteNotifications_WhenOverwriteIsTrue ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            sut.AddNotifications(notifications, true);
            Assert.Equal(2, sut.All().Count);
        }

        [Fact(DisplayName = "05 - AddNotifications must add notifications without overwriting when overwrite is false")]
        public void AddNotifications_ShouldAddNotificationsWithoutOverwriting_WhenOverwriteIsFalse ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            sut.AddNotifications(notifications);
            Assert.Equal(3, sut.All().Count);
        }

        [Fact(DisplayName = "06 - All must return all notifications")]
        public void All_ShouldReturnAllNotifications ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            Assert.Equal(3, sut.All().Count);
        }

        [Fact(DisplayName = "07 - GetBy must throw ArgumentException when condition is null")]
        public void GetBy_ShouldThrowArgumentException_WhenConditionIsNull ()
        {
            var sut = new Notifier<Notification>();
            Assert.Throws<ArgumentException>(() => sut.GetBy(null));            
        }

        [Fact(DisplayName = "08 - GetBy must return notifications matching condition")]
        public void GetBy_ShouldReturnNotificationsMatchingCondition ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            Assert.Equal(3, sut.GetBy(x => x.Key == "any_key").Count);
        }

        [Fact(DisplayName = "09 - GetBy must return null when no notifications match condition")]
        public void GetBy_ShouldReturnNull_WhenNoNotificationsMatchCondition ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            Assert.Null(sut.GetBy(x => x.Key == "other_key"));
        }

        [Fact(DisplayName = "10 - Any must throw ArgumentException when condition is null")]
        public void Any_ShouldThrowArgumentException_WhenConditionIsNull ()
        {
            var sut = new Notifier<Notification>();
            Assert.Throws<ArgumentException>(() => sut.Any(null));
        }

        [Fact(DisplayName = "11 - Any must return true when any notification matches condition")]
        public void Any_ShouldReturnTrue_WhenAnyNotificationMatchesCondition ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            Assert.True(sut.Any(x => x.Key == "any_key"));
        }

        [Fact(DisplayName = "12 - Any must return false when no notifications match condition")]
        public void Any_ShouldReturnFalse_WhenNoNotificationsMatchCondition ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            sut.AddNotification(new("any_key", "any_message"));
            Assert.False(sut.Any(x => x.Key == "other_key"));
        }

        [Fact(DisplayName = "13 - HasNotifications must return true when notifications exist")]
        public void HasNotifications_ShouldReturnTrue_WhenNotificationsExist ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            Assert.True(sut.HasNotifications());
        }

        [Fact(DisplayName = "14 - HasNotifications must return false when no notifications exist")]
        public void HasNotifications_ShouldReturnFalse_WhenNoNotificationsExist ()
        {
            var sut = new Notifier<Notification>();
            Assert.False(sut.HasNotifications());
        }

        [Fact(DisplayName = "15 - Clear must remove all notifications")]
        public void Clear_ShouldRemoveAllNotifications ()
        {
            var sut = new Notifier<Notification>();
            sut.AddNotification(new("any_key", "any_message"));
            sut.Clear();
            Assert.False(sut.HasNotifications());
        }

    }
}
