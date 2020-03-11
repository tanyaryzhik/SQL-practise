using System.Collections.Generic;
using MvvmExample.Model;

namespace MvvmExample.DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void SaveStudents();

        void RemoveStudent(Student student);
    }
}