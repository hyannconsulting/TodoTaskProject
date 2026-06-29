using Microsoft.EntityFrameworkCore;
using Serilog;
using Todo.Api.Endpoints;
using Todo.Infrastructure;
using Todo.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

//var conn = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(conn);
//});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

// Add services to the container.
builder.Services.RegisterDbContext(builder.Configuration);

builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapTodoEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Api v1");
    });
}

app.UseHttpsRedirection();


app.Run();

