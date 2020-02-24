using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
           
            var students = unitOfWork.StudentRepos.Get();
            var courses = unitOfWork.CourseRepos.Get();
            var departments = unitOfWork.DepartmentRepos.Get();

            //ChooseCollectionToDisplay(students, courses, departments);
            //AddStudent(courses);
            //AddCourse(departments);
            //AddDepartment();
            //DisplayCollection(students);
            //DeleteStudent(students);
            //DeleteCourse(courses);
            //DeleteDepartment(departments);
            UpdateStudent(students);
            UpdateCourse(courses);
            UpdateDepartment(departments);
        }

        private static void UpdateDepartment(IEnumerable<Department> departments)
        {
            Console.WriteLine("Input department's ID you want to update");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            var depToUpd = departments.ToList().Find(d => d.Id == inputedId);
            Console.WriteLine($"Department name is {depToUpd.Name}. Input new name");
            depToUpd.Name = Console.ReadLine();
            unitOfWork.DepartmentRepos.Update(depToUpd);
            unitOfWork.Save();
        }

        private static void UpdateCourse(IEnumerable<Course> courses)
        {
            Console.WriteLine("Input courses's ID you want to update");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            var courseToUpd = courses.ToList().Find(c => c.Id == inputedId);
            Console.WriteLine($"Course name is {courseToUpd.Name}. Input new name");
            courseToUpd.Name = Console.ReadLine();
            unitOfWork.CourseRepos.Update(courseToUpd);
            unitOfWork.Save();
        }

        private static void UpdateStudent(IEnumerable<Student> students)
        {
            Console.WriteLine("Input student's ID you want to update");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            var studentToUpd = students.ToList().Find(c => c.Id == inputedId);
            Console.WriteLine($"Student first name is {studentToUpd.FirstName} and last name is {studentToUpd.LastName}." +
                $" Input new first name");
            studentToUpd.FirstName = Console.ReadLine();
            Console.WriteLine($"Input new last name");
            studentToUpd.LastName = Console.ReadLine();
            unitOfWork.StudentRepos.Update(studentToUpd);
            unitOfWork.Save();
        }

        private static void DeleteDepartment(IEnumerable<Department> departments)
        {
            Console.WriteLine("Input department's ID you want to delete");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            unitOfWork.DepartmentRepos.Delete(inputedId);
            unitOfWork.Save();
        }

        private static void DeleteCourse(IEnumerable<Course> courses)
        {
            Console.WriteLine("Input courses's ID you want to delete");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            unitOfWork.CourseRepos.Delete(inputedId);
            unitOfWork.Save();
        }

        private static void ChooseCollectionToDisplay(IEnumerable<Student> students, IEnumerable<Course> courses, IEnumerable<Department> departments)
        {
            Console.WriteLine("Choose entity to work with, Students - s, Courses - c, Departments - d");
            string result = Console.ReadLine();
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
        }

        private static void DeleteStudent(IEnumerable<Student> students)
        {
            Console.WriteLine("Input student's ID you want to delete");
            Int32.TryParse(Console.ReadLine(), out int inputedId);
            //var studToDel = students.ToList().Find(s => s.Id == inputedId);
            //unitOfWork.StudentRepos.Delete(studToDel);
            unitOfWork.StudentRepos.Delete(inputedId);
            unitOfWork.Save();
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
            Console.WriteLine("Input Department Id");
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
