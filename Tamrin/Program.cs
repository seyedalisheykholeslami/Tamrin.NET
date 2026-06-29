using Tamrin.Interfaces;
using Tamrin.Middlewares;
using Tamrin.Models;
using Tamrin.Repositories;
using Tamrin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepo<Person>, PersonRepo>();
builder.Services.AddScoped<PersonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.Run();
