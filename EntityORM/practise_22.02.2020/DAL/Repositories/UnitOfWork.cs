using System;
using System.Collections.Generic;
using System.Text;
using University.DAL.Models;

namespace University.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private UniverDbContext context = new UniverDbContext();
        private GenericRepositry<Student> studentRepos;
        private GenericRepositry<Course> courseRepos;
        private GenericRepositry<Department> departmententRepos;

        public GenericRepositry<Student> StudentRepos
        {
            get
            { 
                if(this.studentRepos == null)
                {
                    this.studentRepos = new GenericRepositry<Student>(context);
                }
                return studentRepos;
            }
        }
        public GenericRepositry<Course> CourseRepos
        {
            get
            {
                if (this.courseRepos == null)
                {
                    this.courseRepos = new GenericRepositry<Course>(context);
                }
                return courseRepos;
            }
        }
        public GenericRepositry<Department> DepartmentRepos
        {
            get
            {
                if (this.departmententRepos == null)
                {
                    this.departmententRepos = new GenericRepositry<Department>(context);
                }
                return departmententRepos;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}