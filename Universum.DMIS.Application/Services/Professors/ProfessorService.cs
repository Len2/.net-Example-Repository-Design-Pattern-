using System;
using System.Collections.Generic;
using System.Linq;
using Universum.DMIS.Application.DTOs;
using Universum.DMIS.Domain.Respositories;

namespace Universum.DMIS.Application.Services.Professors
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }
        public void Add(ProfessorModel professor)
        {
            if(Validate(professor))
                _professorRepository.Add(professor.ToEntity());
        }

        public IEnumerable<ProfessorModel> Get()
        {
            return _professorRepository.Get().Select(professor => new ProfessorModel
            {
                Id = professor.Id,
                FirstName = professor.FirstName,
                LastName = professor.LastName,
                DateOfBirth = professor.DateOfBirth,
                Address = professor.Address
            }).ToList();
        }

        public ProfessorModel GetById(int id)
        {
            var response = _professorRepository.GetById(id);

            return new ProfessorModel
            {
                Id = response.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                DateOfBirth = response.DateOfBirth,
                Address = response.Address
            };
        }

        public int Update(ProfessorModel professor)
        {
            return _professorRepository.Update(professor.ToEntity());
        }

        private bool Validate(ProfessorModel professor)
        {
            if (string.IsNullOrWhiteSpace(professor.FirstName)) return false;
            if (string.IsNullOrWhiteSpace(professor.LastName)) return false;
            if (string.IsNullOrWhiteSpace(professor.Address)) return false;
            if (professor.DateOfBirth.Year < new DateTime().AddYears(-25).Year) return false;

            return true;
        }
    }
}
