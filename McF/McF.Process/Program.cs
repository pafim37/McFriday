using McF.Process.Context;
using Microsoft.EntityFrameworkCore;

namespace McF.Process
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add Postgres database
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("AppDb")));

            // Add services to the container.
            builder.Services.AddControllers();

            WebApplication app = builder.Build();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
