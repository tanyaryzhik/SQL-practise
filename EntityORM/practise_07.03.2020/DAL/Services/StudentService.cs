using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using MvvmExample.Model;

namespace MvvmExample.DAL.Services
{
    public class StudentService : IStudentService
    {
        private StudentDbContext context;
        public StudentService()
        {
            this.context = new StudentDbContext();
        }
        
        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students
                .Include(s => s.Books)
                .Include(s => s.Address);
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            context.SaveChanges();
        }

        public void RemoveStudent(Student student)
        {
            context.Students.Remove(student);
        }
    }
}