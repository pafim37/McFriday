using McF.Process.Context;
using McF.Process.Controllers;
using McF.Process.DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));

            // Add Postgres database
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("AppDb")));

            // Add services to the container.
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddTransient<IRepository, Repository>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductController).Assembly));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            WebApplication app = builder.Build();
            app.UseCors("McFPolicy");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
