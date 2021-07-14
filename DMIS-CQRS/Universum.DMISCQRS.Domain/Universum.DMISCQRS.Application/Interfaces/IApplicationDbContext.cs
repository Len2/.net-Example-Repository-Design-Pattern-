using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Universum.DMISCQRS.Domain.Entities;

namespace Universum.DMISCQRS.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Professor> Professors { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
