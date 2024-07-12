using System.Reflection;
using DemoApi.Core.Models;
using DemoApi.Core.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

namespace DemoApi.Core;

public static class DependencyInjectionExtensions
{
  public static void AddCore(this IServiceCollection services)
  {
    services.AddAutoMapper(typeof(LibraryProfile));
    
    services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(BookViewModel)));
    services.AddFluentValidationAutoValidation();
    services.AddScoped<BooksService>();
  }
}
