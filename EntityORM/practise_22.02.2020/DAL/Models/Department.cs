using System;
using System.Collections.Generic;
using System.Text;

namespace University.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}