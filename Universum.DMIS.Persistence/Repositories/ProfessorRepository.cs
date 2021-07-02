using System.Collections.Generic;
using System.Linq;
using Universum.DMIS.Application.Interfaces;
using Universum.DMIS.Domain.Entities;
using Universum.DMIS.Domain.Respositories;

namespace Universum.DMIS.Persistence.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly IApplicationDbContext _context;
        public ProfessorRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Professor professor)
        {
            _context.Professors.Add(professor);
            _context.SaveChanges();
        }

        public IEnumerable<Professor> Get()
        {
            return _context.Professors.ToList();
        }

        public Professor GetById(int id)
        {
            return _context.Professors.FirstOrDefault(x => x.Id == id);
        }

        public int Update(Professor professor)
        {
            var existingProfessor = _context.Professors.FirstOrDefault(x => x.Id == professor.Id);

            if (existingProfessor == null) return -1;

            existingProfessor.FirstName = professor.FirstName;
            existingProfessor.LastName = professor.LastName;
            existingProfessor.DateOfBirth = professor.DateOfBirth;
            existingProfessor.Address = professor.Address;

            _context.SaveChanges();

            return existingProfessor.Id;
        }
    }
}
