using System;

namespace Universum.DMIS.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public override bool Equals(object obj)
        {
            return ((Student)obj).Id == this.Id;
        }
    }
}