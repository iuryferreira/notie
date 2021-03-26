using System.Collections.Generic;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notie;
using Notie.Contracts;
using Notie.Exceptions;
using Notie.Models;

namespace Tests
{
    [TestClass]
    public class NotificatorTest
    {
        private AbstractNotificator _sut;

        [TestMethod]
        public void Must_Throw_NotificationIsNullException_If_the_Value_Passed_to_AddNotification_Is_Null ()
        {
            _sut = new Notificator();
            Assert.ThrowsException<NotificationIsNullException>(() => _sut.AddNotification(null));
        }

        [TestMethod]
        public void HasNotifications_Property_Must_Return_False_If_No_Notification_Is_Added ()
        {
            _sut = new Notificator();
            Assert.IsFalse(_sut.HasNotifications);
        }

        [TestMethod]
        public void HasNotifications_Property_Must_Return_True_If_Any_Notification_Is_Added ()
        {
            _sut = new Notificator();
            _sut.AddNotification(new("any_key", "any_message"));
            Assert.IsTrue(_sut.HasNotifications);
        }

        [TestMethod]
        public void Must_Return_NotificationIsNullException_If_the_Value_Passed_to_AddNotifications_Is_Null ()
        {
            _sut = new Notificator();
            Assert.ThrowsException<NotificationIsNullException>(() => _sut.AddNotifications(null));
        }

        [TestMethod]
        public void AddNotifications_Should_Receive_a_List_of_Notifications_and_Include_Them_in_Existing_Ones ()
        {
            _sut = new Notificator();
            _sut.AddNotification(new("any_key", "any_message"));
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            _sut.AddNotifications(notifications);
            if (_sut.HasNotifications)
            {

                // Handle...
            }
            Assert.AreEqual(3, _sut.Notifications.Count);
        }

        [TestMethod]
        public void AddNotifications_Must_Overwrite_the_Previous_List_If_the_Overwrite_Property_Is_True ()
        {
            _sut = new Notificator();
            _sut.AddNotification(new("any_key", "any_message"));
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            _sut.AddNotifications(notifications, true);
            Assert.AreEqual(2, _sut.Notifications.Count);
        }

        [TestMethod]
        public void Must_Throw_NotificationIsNullException_If_the_Value_Passed_to_AddNotificationsByFluent_Is_Null ()
        {
            _sut = new Notificator();
            Assert.ThrowsException<ValidationResultIsNullException>(() => _sut.AddNotificationsByFluent(null));
        }

        [TestMethod]
        public void AddNotificationsByFluent_Must_Receive_a_Result_of_Validation_and_Turn_into_Notifications ()
        {
            _sut = new Notificator();
            ExampleEntity entity = new();
            var validator = new Validator();
            _sut.AddNotificationsByFluent(validator.Validate(entity));
            Assert.AreEqual(1, _sut.Notifications.Count);
        }

        [TestMethod]
        public void Must_Throw_NotificationTypeIsNullException_If_the_Value_Passed_to_SetNotificationType_Is_Null ()
        {
            _sut = new Notificator();
            Assert.ThrowsException<NotificationTypeIsNullException>(() => _sut.SetNotificationType(null));
        }

        [TestMethod]
        public void SetNotificationType_Must_Define_the_Type_of_Notification ()
        {
            _sut = new Notificator();
            _sut.SetNotificationType(new("Validation"));
            Assert.AreEqual(_sut.NotificationType.Name, "Validation");
        }

        [TestMethod]
        public void Clear_method_Should_Clear_all_Notifications ()
        {
            _sut = new Notificator();
            List<Notification> notifications = new() { new("any_key", "any_message"), new("any_key", "any_message") };
            _sut.AddNotifications(notifications);
            _sut.Clear();
            Assert.IsFalse(_sut.HasNotifications);
        }

        private class ExampleEntity
        {
            public string Field { get; } = "";
        }

        private class Validator : AbstractValidator<ExampleEntity>
        {
            public Validator ()
            {
                RuleFor(ex => ex.Field).NotEmpty();
            }
        }
    }
}
