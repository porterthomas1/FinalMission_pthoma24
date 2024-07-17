using Microsoft.EntityFrameworkCore;

namespace FinalMission_pthoma24.Models
{
    public class EntertainersDbContext : DbContext
    {
        public EntertainersDbContext(DbContextOptions<EntertainersDbContext> options) : base(options)
        {
        
        }

        public DbSet<Entertainer> Entertainers { get; set; }
    }
}
