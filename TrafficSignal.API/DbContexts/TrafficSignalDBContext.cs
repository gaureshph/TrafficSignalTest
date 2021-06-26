using Microsoft.EntityFrameworkCore;
using TrafficSignal.Web.DomainModels;

namespace TrafficSignal.API.DbContexts
{
    public class TrafficSignalDBContext : DbContext
    {
        public TrafficSignalDBContext(DbContextOptions<TrafficSignalDBContext> options) : base(options)
        {
        }

        public DbSet<TrafficJunction> TrafficJunctions { get; set; }
        public DbSet<TrafficLight> TrafficLights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
