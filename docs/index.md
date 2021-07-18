### ✌ Hello!

Notie is a simple way to implement the Notification Pattern to notify your validations. A difference is that it is multi-purpose, so you can use it for notifications in any class or layer you want. Do what you want! 😄

### 🛠 Install

Use the installation means below.

#### CLI (Linux/Windows/Mac)

To install via the command line (CLI), just run the following command in your project folder:

```bash
  dotnet add package Notie
```

#### NuGet packages managers (Windows/Mac/Linux)

Just search for "Notie" in your Visual Studio/Rider and click on add package.

### 💻 Usage

Notie is intuitive and you can use the documentation provided by the code to help you, but I will also leave examples here.

#### Quick Examples

You can use it in several ways, but here is an example of what it is like to save your notifications:

```csharp
using Notie;

// your validation here...

var notification = new Notification("any_key", "any_message");
var notifier = new Notifier();

notifier.AddNotification(notification);

if (notifier.HasNotifications)
{
  // Handle...
}

```

You can even receive a list of notifications via the `AddNotifications` method. If notifications already exist in the notifier object, they will be merged by default. See example:

```csharp
using Notie;

// your validation here...

List<Notification> notifications = new()
{
  new("any_key", "any_message"),
  new("other_key", "other_message")
};

var notifier = new Notifier();

notifier.AddNotifications(notifications);

if (notifier.HasNotifications)
{
  // Handle...
}

```

if you want to overwrite previous notifications, just set the `overwrite` parameter to `true`, as shown below.

```csharp
using Notie;

// your validation here...
var notifier = new Notifier();
var notification = new Notification("any_key", "any_message");
notifier.AddNotification(notification);

List<Notification> notifications = new()
{
  new("any_key", "any_message"),
  new("other_key", "other_message")
};

var notifier = new Notifier();

notifier.AddNotifications(notifications, true);

if (notifier.HasNotifications)
{
  // Handle...
}

```

if you want to clear all notifications you can do so using the `Clear` method.

#### Using with FluentValidation

You can also receive notifications from FluentValidation through the `AddNotificationsByFluent` method:

```csharp
using Notie;

Entity entity = new Entity();
EntityValidator validator = new EntityValidator();
ValidationResult result = validator.Validate(entity);

var notifier = new Notifier();
notifier.AddNotificationsByFluent(result);

if (notifier.HasNotifications)
{
  // Handle...
}
```

#### Defining notification types

Each notifier can be in a different context, and for that we can define types for it through the `NotificationType` property. You can have notifications from repository, validation or any other service you need, so you can separate the notifications from each context and understand which part of the application is bringing the notifications. initial type of `NotificationType` is `"Default"`. See example below:

```csharp
using Notie;

// In the repository

var notifier = new Notifier();
notifier.SetNotificationType("Repository");

// In the Domain

var notifier = new Notifier();
notifier.SetNotificationType("Validation");

// In the user service

var notifier = new Notifier();
notifier.SetNotificationType("Service");

```

This documentation will be increased as the project progresses, but issues can open, which I will answer as quickly as I can, I am happy with your comment. 😄