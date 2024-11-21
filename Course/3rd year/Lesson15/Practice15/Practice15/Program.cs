using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Practice15.Data;
using Practice15.Interfaces;
using Practice15.Services;

namespace Practice15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            string connectionNotesString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<NoteContext>(options => options.UseSqlite(connectionNotesString));

            builder.Services.AddScoped<DatabaseLoggingManager>();

            builder.Services.AddScoped<ConsoleLoggingManager>();

            builder.Services.AddScoped<INoteManager, NoteManager>();


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
        }
    }
}
