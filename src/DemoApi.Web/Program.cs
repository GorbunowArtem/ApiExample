using System.Reflection;
using DemoApi.Core;
using DemoApi.Core.Models;
using DemoApi.Core.Services;
using DemoApi.Infrastructure;
using DemoApi.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<BooksContext>(options =>
    // options.UseNpgsql(builder.Configuration.GetConnectionString("BookContext")));
    options.UseInMemoryDatabase("BookContext"));

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(BookViewModel)));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<BooksContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy => { policy.WithOrigins("http://localhost:3000"); });
});

builder.Services.AddCore();
builder.Services.AddInfrastructure();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BooksContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors("ReactPolicy");
app.UseGlobalExceptionHandling();

app.MapIdentityApi<IdentityUser>();

app.MapGet("/books", async (BooksService service) => await service.GetBooksAsync())
    .RequireAuthorization();;


app.MapPut("/books", () =>
{
    throw new NotImplementedException();
    return Results.Ok();
});

app.MapPost("/books", async (BookViewModel book, BooksService service) =>
{
    await service.AddBookAsync(book);
    return Results.Created();
});

app.Run();