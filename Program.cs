using EfCoreSoftDelete.Data;
using EfCoreSoftDelete.Data.Entities;
using EfCoreSoftDelete.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SoftDeleteInterceptor>();

builder.Services.AddDbContext<ApplicationContext>(
    (sp, options) => options
        .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .AddInterceptors(
            sp.GetRequiredService<SoftDeleteInterceptor>()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.MapPost("/books", async (CreateBookRequest request, ApplicationContext context) =>
{
    var book = new Book
    {
        Id = Guid.NewGuid(),
        Name = request.Name
    };
    
    await context.Books.AddAsync(book);
    await context.SaveChangesAsync();
    
    return Results.Ok(book);
})
.WithName("CreateBook")
.WithOpenApi();

app.MapDelete("/books/{id:guid}", async (Guid id, ApplicationContext context) =>
{
    var book = await context.Books
        .FirstOrDefaultAsync(x => x.Id == id);

    if (book is not null)
    {
        context.Books.Remove(book);
        await context.SaveChangesAsync();
    }

    return Results.Ok();
})
.WithName("DeleteBooks")
.WithOpenApi();

app.MapGet("/books", async (ApplicationContext context) => 
        Results.Ok((object?)await context.Books
            .AsNoTracking()
            .ToListAsync()))
.WithName("ListBooks")
.WithOpenApi();

app.Run();