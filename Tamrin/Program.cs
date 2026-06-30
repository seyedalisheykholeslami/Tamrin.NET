using Tamrin.ActionFilter;
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
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthActionFilter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseMiddleware<AuthorizationMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
