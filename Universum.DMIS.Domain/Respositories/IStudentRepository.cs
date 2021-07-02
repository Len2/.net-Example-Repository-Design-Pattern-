using System.Collections.Generic;
using Universum.DMIS.Domain.Entities;

namespace Universum.DMIS.Domain.Respositories
{
    public interface IStudentRepository
    {
        void Add(Student student);
        int Update(Student student);
        Student GetById(int id);
        IEnumerable<Student> Get();
    }
}
