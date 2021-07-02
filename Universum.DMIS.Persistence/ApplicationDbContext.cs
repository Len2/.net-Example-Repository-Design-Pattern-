using Microsoft.EntityFrameworkCore;
using Universum.DMIS.Application.Interfaces;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {  
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
