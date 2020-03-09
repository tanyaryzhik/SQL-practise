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
            return context.Students;
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            context.SaveChanges();
        }

        public void RemoveStudent(Student student)
        {
            context.Students.Remove(student);
        }

        public void LoadBooksAdrs(int studentId)
        {
            context.Students
                .Where(s => s.Id == studentId)
                .Include(s => s.Books)
                .Include(s => s.Address)
                .FirstOrDefault();
        }
    }
}