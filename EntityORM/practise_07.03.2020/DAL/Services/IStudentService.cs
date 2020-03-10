using System.Collections.Generic;
using MvvmExample.Model;

namespace MvvmExample.DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void SaveStudents(IEnumerable<Student> students);

        void RemoveStudent(Student student);
    }
}