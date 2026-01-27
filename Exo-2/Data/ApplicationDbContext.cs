using Exo_2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exo_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Musique> Music { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
