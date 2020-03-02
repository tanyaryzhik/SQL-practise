using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.DAL.Models;

namespace University.DAL.Repositories
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private UniverDbContext univerDbContext;

        public StudentRepository(UniverDbContext context)
        {
            this.univerDbContext = context;
        }

        public void DeleteStudent(int studentId)
        {
            Student student = univerDbContext.Students.SingleOrDefault(s => s.Id == studentId);
            if (student == null)
                return;
            univerDbContext.Students.Remove(student);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                   univerDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Student GetStudentById(int studentId)
        {
            return univerDbContext.Students.Find(studentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return univerDbContext.Students.ToList();
        }

        public void InsertStudent(Student student)
        {
            univerDbContext.Students.Add(student);
        }

        public void Save()
        {
            univerDbContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            univerDbContext.Entry(student).State = EntityState.Modified;
        }
    }
}