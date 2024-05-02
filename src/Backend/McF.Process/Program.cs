using Mcf.Order.Service.Controllers;
using Mcf.Order.Service.DAL;
using McF.Product.Service.Context;
using McF.Product.Service.Controllers;
using McF.Product.Service.DAL;
using Microsoft.EntityFrameworkCore;

namespace McF.Process
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Logs
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // CORS
            builder.Services.AddCors(o => o.AddPolicy("McFPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));

            // Add Postgres database
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddDbContext<Mcf.Order.Service.Context.OrderContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("AppDb")));
            builder.Services.AddDbContext<ProductContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("AppDb")));

            // Add services to the container.
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductController).Assembly));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OrderController).Assembly));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            WebApplication app = builder.Build();
            app.UseCors("McFPolicy");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
