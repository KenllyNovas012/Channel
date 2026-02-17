using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AplicationDataContext:DbContext
    {
        public AplicationDataContext(DbContextOptions options): base(options)
        {
                
        }
        public DbSet<Channel> Channels { get; set; }

    }
}
