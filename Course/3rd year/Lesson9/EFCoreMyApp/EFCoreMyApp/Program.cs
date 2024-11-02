using EFCoreMyApp.services.context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using EFCoreMyApp.services.implementations;
using EFCoreMyApp.services.interfaces;
using System.Text.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

string connectionTasks = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TaskContext>(options => options.UseSqlite(connectionTasks));

builder.Services.AddScoped<ITaskManager, TaskManager>();

builder.Services.AddScoped<TaskManager>();

var app = builder.Build();
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
