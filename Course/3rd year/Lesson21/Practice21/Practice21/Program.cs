using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice21.Models;

namespace Practice21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionPath = "Data Source=data.db";

            var builder = new ServiceCollection()
                .AddDbContext<BookAppContext>(opt => opt.UseSqlite(connectionPath))
                .BuildServiceProvider();

            using (var context = builder.GetRequiredService<BookAppContext>())
            {
                context.Database.EnsureCreated();

                var authors = context.authors.ToList();

                foreach (var author in authors)
                {
                    Console.WriteLine(author.AuthorName);
                }
            }
        }
    }
}
