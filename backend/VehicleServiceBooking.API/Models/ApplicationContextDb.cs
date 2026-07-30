using Microsoft.EntityFrameworkCore;
using VehicleServiceBooking.API.Models;

namespace VehicleServiceBooking.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
    }
}