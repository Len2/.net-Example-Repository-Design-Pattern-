using System;
using System.Collections.Generic;
using System.Linq;
using Universum.DMIS.Application.DTOs;
using Universum.DMIS.Domain.Respositories;

namespace Universum.DMIS.Application.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void Add(StudentModel student)
        {
            if (Validate(student))
                _studentRepository.Add(student.ToEntity());
        }

        public IEnumerable<StudentModel> Get()
        {
            return _studentRepository.Get().Select(student => new StudentModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address
            }).ToList();
        }

        public StudentModel GetById(int id)
        {
            var response = _studentRepository.GetById(id);

            return new StudentModel
            {
                Id = response.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                DateOfBirth = response.DateOfBirth,
                Address = response.Address
            };
        }

        public int Update(StudentModel student)
        {
            return _studentRepository.Update(student.ToEntity());
        }

        private bool Validate(StudentModel student)
        {
            if (string.IsNullOrWhiteSpace(student.FirstName)) return false;
            if (string.IsNullOrWhiteSpace(student.LastName)) return false;
            if (string.IsNullOrWhiteSpace(student.Address)) return false;

            return true;
        }
    }
}
