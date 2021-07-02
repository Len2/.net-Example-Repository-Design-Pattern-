using System;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Application.DTOs
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Student ToEntity()
        {
            return new Student
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Address = Address
            };
        }
    }
}
