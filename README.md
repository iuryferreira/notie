<p align="center">
  <img alt="Notie" title="Notie" src=".github/assets/logo.png" width="400px" />
</p>
<h3 align="center">
    Notificações de maneira simples no .NET
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

<p align="center" style="font-size:10px">Don't know portuguese? check the documentation in english <a href="docs/en-us.md">here</a>.</p>



### ✌ Olá!

Notie é uma maneira simples de implementar o *Notification Pattern* para agrupar suas validações. A diferença é que ele é multifuncional, então você pode usá-lo para notificações em qualquer classe ou camada que desejar. Faça o que você quiser! 😄

### 🛠 Instalação

Use os meios de instalação abaixo.

#### CLI (Linux/Windows/Mac)

Para instalar pela linha de comando (CLI), basta executar o seguinte comando na pasta do seu projeto:

```bash
  dotnet add package Notie
```

#### Gerenciador de pacotes NuGet (Windows/Mac/Linux)

Basta pesquisar por "Notie" em seu Visual Studio/Rider e clicar em adicionar pacote.

### 💻 Formas de uso

Notie é intuitivo e você pode usar a documentação fornecida pelo código para ajudá-lo, mas também deixarei exemplos aqui.

#### Exemplos

Você pode usá-lo de várias maneiras, mas aqui está um exemplo de como salvar suas notificações:

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

Você pode até receber uma lista de notificações por meio do método `AddNotifications`. Se as notificações já existirem no notificador, elas serão mescladas por padrão. Consultar exemplo:

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

Se você quiser sobrescrever as notificações anteriores, apenas defina o parâmetro `overwrite` como` true`, conforme mostrado abaixo.

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

Se você deseja limpar todas as notificações, pode fazê-lo usando o método `Clear`.

#### Combinando com o FluentValidation

Você também pode receber notificações do FluentValidation por meio do método `AddNotificationsByFluent`:

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

#### Definindo tipos de notificação

Cada notificador pode estar em um contexto diferente, e para isso podemos definir tipos para ele através da propriedade `NotificationType`. Você pode ter notificações de repositório, validação ou qualquer outro serviço que precisar, então você pode separar as notificações de cada contexto e entender qual parte do aplicativo está trazendo as notificações. Por padrão o valor para o `NotificationType` é `"Default"`. Veja o exemplo abaixo:

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

Essa documentação será incrementada conforme o projeto avança. Caso tenha dúvidas contate-me ou abra uma *issue*, a qual responderei o mais rápido possível. Fico feliz com seu comentário. 😄
