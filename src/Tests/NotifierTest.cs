using System.Collections.Generic;
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
}
