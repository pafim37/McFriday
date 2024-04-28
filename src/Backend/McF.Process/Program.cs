using McF.Process.Context;
using McF.Process.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
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
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); // TODO: improve cors policy
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

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            WebApplication app = builder.Build();
            app.UseCors("McFPolicy");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
