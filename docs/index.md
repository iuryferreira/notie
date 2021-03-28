<p align="center">
  <img alt="Notie" title="Notie" src="../.github/assets/logo.png" width="400px" />
</p>
<h3 align="center">
    Your notifications in a simpler way on .NET
</h3>

<p align="center">

  <a href="https://dotnet.microsoft.com/">
    <img alt="GitHub language count" src="https://img.shields.io/badge/language-1-blue">
  </a>

  <a href="https://github.com/iuryferreira/">
    <img alt="Made by Iury Ferreira" src="https://img.shields.io/badge/made%20by-Iury%20Ferreira-blue">
  </a>

  <a href="https://nuget.org/packages/Notie">
    <img alt="Version" src="https://img.shields.io/nuget/v/notie">
  </a>

<a href="https://nuget.org/packages/Notie">
    <img alt="Downloads" src="https://img.shields.io/nuget/dt/notie">
 </a>
 
<a href='https://coveralls.io/github/iuryferreira/notie?branch=main'>
  <img src='https://coveralls.io/repos/github/iuryferreira/notie/badge.svg?branch=main' alt='Coverage Status'/>
</a>

<a href="hhttps://github.com/iuryferreira/notie/actions/workflows/publish.yaml">
    <img alt="Version" src="https://github.com/iuryferreira/notie/actions/workflows/publish.yaml/badge.svg?branch=main">
</a>

</p>

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

var notification = new Notification(key: "any_key", message: "any_message");
var notificator = new Notificator();

notificator.AddNotification(notification);

if (_sut.HasNotifications)
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

var notificator = new Notificator();

notificator.AddNotifications(notifications);

if (_sut.HasNotifications)
{
  // Handle...
}

```

if you want to overwrite previous notifications, just set the `overwrite` parameter to `true`, as shown below.

```csharp
using Notie;

// your validation here...
var notificator = new Notificator();
var notification = new Notification(key: "any_key", message: "any_message");
notificator.AddNotification(notification);

List<Notification> notifications = new()
{
  new("any_key", "any_message"),
  new("other_key", "other_message")
};

var notificator = new Notificator();

notificator.AddNotifications(notifications, true);

if (_sut.HasNotifications)
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

var notificator = new Notificator();
notificator.AddNotificationsByFluent(result);

if (_sut.HasNotifications)
{
  // Handle...
}
```

#### Defining notification types

Each notifier can be in a different context, and for that we can define types for it through the `NotificationType` property. You can have notifications from repository, validation or any other service you need, so you can separate the notifications from each context and understand which part of the application is bringing the notifications. initial type of `NotificationType` is `"Default"`. See example below:

```csharp
using Notie;

// In the repository

var notificator = new Notificator();
notificator.SetNotificationType(new("Repository"));

// In the Domain

var notificator = new Notificator();
notificator.SetNotificationType(new("Validation"));

// In the user service

var notificator = new Notificator();
notificator.SetNotificationType(new("Service"));

```

This documentation will be increased as the project progresses, but issues can open, which I will answer as quickly as I can, I am happy with your comment. 😄

### 👋 Bye!

Made with 💻 by Iury :wave: [See my linkedin!](https://www.linkedin.com/in/iury-ferreira-68ba35130/)
