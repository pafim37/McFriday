using McF.Process.Context;
using McF.Process.DAL;
using Microsoft.EntityFrameworkCore;

namespace McF.Process
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // CORS
            builder.Services.AddCors(o => o.AddPolicy("McFPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); // TODO: improve cors policy
            }));

            // Add Postgres database
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("AppDb")));

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddTransient<IRepository, Repository>();

            WebApplication app = builder.Build();
            app.UseCors("McFPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
