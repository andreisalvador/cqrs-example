using Cqrs.Example.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Example.Infrastructure.Data
{
    public class CqrsExampleContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public CqrsExampleContext(DbContextOptions<CqrsExampleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CqrsExampleContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
