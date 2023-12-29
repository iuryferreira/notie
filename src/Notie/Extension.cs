using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Notie.Contracts;

namespace Notie;

[ExcludeFromCodeCoverage]
public static class Extension
{
    public static void AddNotie (this IServiceCollection services)
    {
        services.AddScoped<INotifier, Notifier>();
    }
}