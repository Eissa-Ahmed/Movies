using Microsoft.EntityFrameworkCore;
using Movie.DAL.Entity;

namespace Movie.DAL.Database
{
    public class ApllicationDbContext : DbContext
    {
        public ApllicationDbContext(DbContextOptions<ApllicationDbContext> option) : base(option) { }
        public DbSet<Geners> Geners { get; set; }
        public DbSet<Movies> Movies { get; set; }
    }
}
