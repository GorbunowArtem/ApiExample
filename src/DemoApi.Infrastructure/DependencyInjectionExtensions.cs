using DemoApi.Core;
using DemoApi.Infrastructure.Persistense;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApi.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();
    }
}