using System;
using System.Collections.Generic;
using FluentValidation.Results;
using Notie.Models;

namespace Notie.Contracts;

/// <summary>
///     The Notifier interface.
///     Provides notification management, allowing adding, retrieving, and clearing notifications.
/// </summary>
public interface INotifier
{

    #region Add

    /// <summary>
    ///     Add a notification to the notification list.
    /// </summary>
    /// <param name="key">Non-null notification key.</param>
    /// <param name="message">Non-null notification message.</param>
    /// <exception cref="Exceptions.NotificationIsNullException">
    ///     The exception is thrown when a null
    ///     notification is passed to the method that does not allow this operation.
    /// </exception>
    void AddNotification (string key, string message);


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
    /// ///
    /// <param name="overwrite">If true, it overwrites all notifications that already exist in the notifier.</param>
    /// <exception cref="Exceptions.ValidationResultIsNullException">
    ///     The exception is thrown when a null
    ///     validation is passed to the method that does not allow this operation.
    /// </exception>
    void AddNotificationsByFluent (ValidationResult validationResult, bool overwrite = false);

    #endregion

    #region Get

    /// <summary>
    ///     List all notifications.
    /// </summary>
    IReadOnlyCollection<Notification> All ();

    /// <summary>
    ///     Get a notification for the entered key.
    /// </summary>
    /// <param name="key">Non-empty key to search the notifications list.</param>
    /// <exception cref="ArgumentException">
    ///     The exception is thrown when a empty or null
    ///     key is passed to the method that does not allow this operation.
    /// </exception>
    IReadOnlyCollection<Notification> GetByKey (string key);

    /// <summary>
    ///     Get a notification for the entered message.
    /// </summary>
    /// <param name="message">Non-empty message to search the notifications list.</param>
    /// <exception cref="ArgumentException">
    ///     The exception is thrown when a empty or null
    ///     message is passed to the method that does not allow this operation.
    /// </exception>
    IReadOnlyCollection<Notification> GetByMessage (string message);

    /// <summary>
    ///     Get a notification for the entered condition.
    /// </summary>
    /// <param name="condition">Non-null condition to search the notifications list.</param>
    /// <exception cref="ArgumentException">
    ///     The exception is thrown when a empty or null
    ///     condition is passed to the method that does not allow this operation.
    /// </exception>
    IReadOnlyCollection<Notification> GetBy (Func<Notification, bool> condition);

    /// <summary>
    ///     Checks whether a given notification exists based on a given condition.
    /// </summary>
    /// <param name="condition">Non-null condition to check in the notifications list.</param>
    /// <exception cref="ArgumentException">
    ///     The exception is thrown when a empty or null
    ///     condition is passed to the method that does not allow this operation.
    /// </exception>
    public bool Any (Func<Notification, bool> condition);

    #endregion

    #region Others

    /// <summary>
    ///     Check the notifier for notifications.
    /// </summary>
    bool HasNotifications ();

    /// <summary>
    ///     Remove all notifications.
    /// </summary>
    void Clear ();

    #endregion

}

public interface INotifier<T>
{

    #region Add

    /// <summary>
    ///     Add a notification to the notification list.
    /// </summary>
    /// <param name="notification">Non-null notification to be inserted into the notifier.</param>
    /// <exception cref="Exceptions.NotificationIsNullException">
    ///     The exception is thrown when a null
    ///     notification is passed to the method that does not allow this operation.
    /// </exception>
    void AddNotification (T notification);

    /// <summary>
    ///     Inserts or rewrites a list of notifications in the existing list.
    /// </summary>
    /// <param name="notifications">Non-null list of notifications to be inserted into the notifier.</param>
    /// <param name="overwrite">If true, it overwrites all notifications that already exist in the notifier.</param>
    /// <exception cref="Exceptions.NotificationIsNullException">
    ///     The exception is thrown when a null
    ///     notification is passed to the method that does not allow this operation.
    /// </exception>
    void AddNotifications (IEnumerable<T> notifications, bool overwrite = false);

    /// <summary>
    ///     Inserts notifications from a FluentValidation validation.
    /// </summary>
    /// <param name="validationResult">Non-null result of a FluentValidation validator.</param>
    /// /// <param name="overwrite">If true, it overwrites all notifications that already exist in the notifier.</param>
    /// <exception cref="Exceptions.ValidationResultIsNullException">
    ///     The exception is thrown when a null
    ///     validation is passed to the method that does not allow this operation.
    /// </exception>

    #endregion

    #region Get

    /// <summary>
    ///     List all notifications.
    /// </summary>
    IReadOnlyCollection<T> All ();

    /// <summary>
    ///     Get a notification for the entered key.
    /// </summary>
    /// <param name="key">Non-empty key to search the notifications list.</param>
    /// <exception cref="ArgumentException">
    ///     The exception is thrown when a empty or null
    ///     key is passed to the method that does not allow this operation.
    /// </exception>
    IReadOnlyCollection<T> GetBy (Func<T, bool> condition);

    /// <summary>
    ///     Checks whether a given notification exists based on a given condition.
    /// </summary>
    /// <param name="condition">Non-null condition to check in the notifications list.</param>
    /// <exception cref="ArgumentException">
    ///     The exception is thrown when a empty or null
    ///     condition is passed to the method that does not allow this operation.
    /// </exception>
    public bool Any (Func<T, bool> condition);

    #endregion

    #region Others

    /// <summary>
    ///     Check the notifier for notifications.
    /// </summary>
    bool HasNotifications ();

    /// <summary>
    ///     Remove all notifications.
    /// </summary>
    void Clear ();

    #endregion

}
