using First.Behaviors;
using First.Domain;
using First.Exceptions;
using First.Features.Products.Commands.Create;
using First.Features.Products.Commands.Delete;
using First.Features.Products.Commands.Update;
using First.Features.Products.Notifications;
using First.Features.Products.Queries.Get;
using First.Features.Products.Queries.List;
using First.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddSwaggerGen(c =>
{
    //c.IncludeXmlComments(string.Format(@"{0}\OnionArchitecture.xml", System.AppDomain.CurrentDomain.BaseDirectory));
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "OnionArchitecture",
    });

});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnionArchitecture");
});

app.MapGet("/products/{id:guid}", async (Guid id, ISender mediatr) =>

{
    var product = await mediatr.Send(new GetProductQuery(id));

    if (product == null) return Results.NotFound();

    return Results.Ok(product);
});


app.MapGet("/products", async (ISender mediatr) =>

{
    var products = await mediatr.Send(new ListProductsQuery());

    return Results.Ok(products);
});


app.MapPost("/products", async (CreateProductCommand command, IMediator mediatr) =>
{
    var productId = await mediatr.Send(command);

    if (Guid.Empty == productId) return Results.BadRequest();

    await mediatr.Publish(new ProductCreatedNotification(productId));

    return Results.Created($"/products/{productId}", new { id = productId });
});

app.MapPut("/products", async (Product product, ISender mediatr) =>
{
    await mediatr.Send(new UpdateProductCommand(product));
    return Results.NoContent();
});

app.MapDelete("/products/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteProductCommand(id));
    return Results.NoContent();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
