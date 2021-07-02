using Microsoft.EntityFrameworkCore;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Professor> Professors { get; set; }
        int SaveChanges();
    }
}
