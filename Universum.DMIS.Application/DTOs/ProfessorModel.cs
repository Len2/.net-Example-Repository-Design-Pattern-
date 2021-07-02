using System;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Application.DTOs
{
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public Professor ToEntity()
        {
            return new Professor
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
