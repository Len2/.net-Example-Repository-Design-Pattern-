using System;
using System.Collections.Generic;
using System.Linq;
using Universum.DMIS.Application.Interfaces;
using Universum.DMIS.Domain.Entities;
using Universum.DMIS.Domain.Respositories;

namespace Universum.DMIS.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IApplicationDbContext _context;
        public StudentRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> Get()
        {
            return _context.Students.OrderByDescending(x => x.Id).ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public int Update(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(x => x.Id == student.Id);

            if (existingStudent == null) return -1;

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Address = student.Address;

            _context.SaveChanges();

            return existingStudent.Id;
        }
    }
}
