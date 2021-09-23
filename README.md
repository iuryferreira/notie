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

Ele contém uma classe `Notifier` que é responsável por gerenciar as notificações do tipo `Notification`. 

### 🛠 Instalação

Use os meios de instalação abaixo.

#### CLI (Linux/Windows/Mac)

Para instalar pela linha de comando (CLI), basta executar o seguinte comando na pasta do seu projeto:

```bash
  dotnet add package Notie
```

#### Gerenciador de pacotes NuGet (Windows/Mac/Linux)

Basta pesquisar por "Notie" em seu Visual Studio/Rider e clicar em adicionar pacote.

### 💻 Funcionamento

Notie é intuitivo e você pode usar a documentação fornecida pelo código para ajudá-lo, mas também deixarei exemplos aqui.

#### AddNotification

O AddNotification recebe um objeto `Notification` que contém uma chave e valor, que poderia ser o campo e a mensagem que deseja informar.

```csharp
using Notie;

// your validation here...

var notification = new Notification("any_key", "any_message");
INotifier notifier = new Notifier();

notifier.AddNotification(notification);

if (notifier.HasNotifications())
{
  // Handle...
}

```

No caso acima, você cria um objeto da classe `Notification` e adiciona ao seu `Notifier`.

#### AddNotifications


Você pode receber uma lista de notificações por meio do método `AddNotifications`. Se já existirem notificações no `Notifier`, elas serão mescladas por padrão. Consultar exemplo:

```csharp
using Notie;

// your validation here...

List<Notification> notifications = new()
{
  new("any_key", "any_message"),
  new("other_key", "other_message")
};

INotifier notifier = new Notifier();

notifier.AddNotifications(notifications);

if (notifier.HasNotifications())
{
  // Handle...
}

```

Se você quiser sobrescrever as notificações anteriores, apenas defina o parâmetro `overwrite` como` true`, conforme mostrado abaixo.

```csharp
// ...

notifier.AddNotifications(notifications, overwrite: true);

if (notifier.HasNotifications())
{
  // Handle...
}

```

#### AddNotificationsByFluent

O Notie tem suporte ao FluentValidation. Se você o utiliza para realizar as validações, você pode integrá-las através do método `AddNotificationsByFluent`, passando um `ValidationResult`.

```csharp
using Notie;

Entity entity = new Entity();
EntityValidator validator = new EntityValidator();
ValidationResult result = validator.Validate(entity);

INotifier notifier = new Notifier();
notifier.AddNotificationsByFluent(result);

if (notifier.HasNotifications())
{
  // Handle...
}
```

Se você quiser sobrescrever as notificações anteriores, apenas defina o parâmetro `overwrite` como` true`, conforme mostrado abaixo.

```csharp
// ...

notifier.AddNotificationsByFluent(notifications, overwrite: true);

if (notifier.HasNotifications())
{
  // Handle...
}

```
#### All

Para listar todas as notificações contidas no `Notifier` basta chamar o método `All`, como mostra o exemplo abaixo:


```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

notifier.All()

```

#### HasNotifications

Para verificar se existem notificações no `Notifier` basta chamar o método `HasNotifications`, como mostra o exemplo abaixo:


```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

bool exists = notifier.HasNotifications()

```

#### GetByKey

Se você deseja obter notificações baseadas nas chaves, poderá utilizar o método `GetByKey`. Você fornece o nome da chave e recebe uma lista das notificações que contém a chave informada, como no exemplo abaixo:

```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

var notifications = notifier.GetByKey("any_key")

```

#### GetByMessage

Se você deseja obter notificações baseadas nas mensagens, poderá utilizar o método `GetByMessage`. Você fornece uma mensagem e recebe uma lista das notificações que contém a mensagem informada, como no exemplo abaixo:

```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

var notifications = notifier.GetByMessage("any_message")

```

#### GetBy
Você também pode passar uma expressão para o método `GetBy`. Assim você pode verificar através da mensagem e da chave, caso preferir.

```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

var notifications = notifier.GetBy(x => x.Key == "any_key" && x.Message == "any_message")

```

#### Any

O método `Any` é responsável por verificar se existe uma notificação baseado na expressão informada.

```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

bool exists = notifier.Any(x => x.Key == "any_key" && x.Message == "any_message")

```

#### Clear


Se você deseja limpar todas as notificações, pode fazê-lo usando o método `Clear`.

```csharp
using Notie;

INotifier notifier = new Notifier();

// ...

notifier.Clear()

```








### ℹ Injeção de Dependência

Se você deseja utilizar com ASP.NET ou consumir via construtor, você pode adicionar a sua coleção de serviços `IServiceCollection`. Basta inserir no seu arquivo `Statup.cs` no método `ConfigureServices` a seguinte chamada:

```csharp
using Notie;

// ...

public void ConfigureServices (IServiceCollection services)
{
  services.AddNotie();
}

// ...

```

### 📢 Observações

Essa documentação será incrementada conforme o projeto avança. Caso tenha dúvidas contate-me ou abra uma *issue*, a qual responderei o mais rápido possível. Fico feliz com seu comentário. 😄
