using Microsoft.EntityFrameworkCore;
using VehicleServiceBooking.API.Data;

namespace VehicleServiceBooking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // MySQL Database Connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("ConStr"),
                    ServerVersion.AutoDetect(
                        builder.Configuration.GetConnectionString("ConStr")
                    )
                )
            );


            // Add MVC Controllers
            builder.Services.AddControllers();


            // Swagger Configuration (.NET 9)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();


            // Configure HTTP pipeline
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