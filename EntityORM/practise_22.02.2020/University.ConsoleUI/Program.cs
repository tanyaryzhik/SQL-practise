using System;
using System.Collections;
using System.Collections.Generic;
using University.DAL;
using University.DAL.Models;
using University.DAL.Repositories;

namespace University.ConsoleUI
{
    class Program
    {
        private static UnitOfWork unitOfWork = new UnitOfWork();
        static void Main(string[] args)
        {
            Console.WriteLine("Choose entity to work with, Students - s, Courses - c, Departments - d");
            string result = Console.ReadLine();
            var students = unitOfWork.StudentRepos.Get();
            var courses = unitOfWork.CourseRepos.Get();
            var departments = unitOfWork.DepartmentRepos.Get();
            switch (result)
            {
                case "s":
                    {
                        DisplayCollection(students);
                        break;
                    }
                case "c":
                    {
                        DisplayCollection(courses);
                        break;
                    }
                case "d":
                    {
                        DisplayCollection(departments);
                        break;
                    }
                default:
                    break;
            }
            AddStudent(courses);
            AddCourse(departments);
            AddDepartment();
            DisplayCollection(students);

        }

        private static void AddDepartment()
        {
            Console.WriteLine("Add department to list of department");
            Department departmentToAdd = new Department();
            Console.WriteLine("Input Department name");
            departmentToAdd.Name = Console.ReadLine();
            unitOfWork.DepartmentRepos.Insert(departmentToAdd);
            unitOfWork.Save();
        }

        private static void DisplayCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void AddStudent(IEnumerable<Course> courses)
        {
            Console.WriteLine("Add student to list of students");
            Student studentToAdd = new Student();
            Console.WriteLine("Input First name");
            studentToAdd.FirstName = Console.ReadLine();
            Console.WriteLine("Input Last name");
            studentToAdd.LastName = Console.ReadLine();
            Console.WriteLine("Input Course Id");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            foreach (var item in courses)
            {
                if (item.Id == inputedId)
                    studentToAdd.Course = item;
            }
            unitOfWork.StudentRepos.Insert(studentToAdd);
            unitOfWork.Save();
        }

        private static void AddCourse(IEnumerable<Department> departments)
        {
            Console.WriteLine("Add course to list of courses");
            Course courseToAdd = new Course();
            Console.WriteLine("Input Course name");
            courseToAdd.Name = Console.ReadLine();
            Console.WriteLine("Input Course Id");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            foreach (var item in departments)
            {
                if (item.Id == inputedId)
                    courseToAdd.Department = item;
            }
            unitOfWork.CourseRepos.Insert(courseToAdd);
            unitOfWork.Save();
        }
    }
}
