using System.Collections.Generic;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Domain.Respositories
{
    public interface IProfessorRepository
    {
        void Add(Professor professor);
        int Update(Professor professor);
        Professor GetById(int id);
        IEnumerable<Professor> Get();
    }
}
