
using Microsoft.EntityFrameworkCore;
using Practice27.Context;
using Practice27.Managers;

namespace Practice27
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = "Host=localhost;Port=5432;Database=practice27;Username=postgres;Password=batareyka";

            builder.Services.AddDbContext<UserContext>((options) => options.UseNpgsql(connectionString));
            builder.Services.AddScoped<UserManager>();

            var app = builder.Build();

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
