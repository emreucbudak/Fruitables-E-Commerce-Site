using FruitablesAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.Context;
using Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSql(builder.Configuration );
builder.Services.ConfigureRepositoryItems();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceItems();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
