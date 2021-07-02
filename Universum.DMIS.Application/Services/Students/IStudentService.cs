using System;
using System.Collections.Generic;
using System.Text;
using Universum.DMIS.Application.DTOs;

namespace Universum.DMIS.Application.Services.Students
{
    public interface IStudentService
    {
        void Add(StudentModel student);
        int Update(StudentModel student);
        IEnumerable<StudentModel> Get();
        StudentModel GetById(int id);
    }
}
