using CodeFirst_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                //var student = context.Students.Where(s => s.Name == "Smith").FirstOrDefault();
                //context.Entry(student).Reference(s => s.Grade).Load();

                //var grade = context.Grades.FirstOrDefault();
                //context.Entry(grade).Collection(g => g.Students).Load();

                //var students = context.Students.OrderBy(s => s.Id).ToList();
                //foreach (var item in students)
                //{
                //    Console.WriteLine(item.Name);
                //}

                //var studentWithGrade = context.Students.Where(s => s.Name == "Smith").Include(s => s.Grade).FirstOrDefault();
                IList<Student> studList = context.Students.ToList<Student>();
                Student std = studList[0];
               // Grade grade = std.Grade;
            }
        }
    }
}
