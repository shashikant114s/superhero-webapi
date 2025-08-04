using Microsoft.EntityFrameworkCore;
using SuperHeros.Entities;

namespace SuperHeros.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
