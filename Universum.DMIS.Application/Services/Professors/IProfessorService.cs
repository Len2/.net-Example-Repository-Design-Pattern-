using System.Collections.Generic;
using Universum.DMIS.Application.DTOs;

namespace Universum.DMIS.Application.Services.Professors
{
    public interface IProfessorService
    {
        void Add(ProfessorModel professor);
        int Update(ProfessorModel professor);
        IEnumerable<ProfessorModel> Get();
        ProfessorModel GetById(int id);
    }
}
