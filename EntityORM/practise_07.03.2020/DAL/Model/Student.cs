using DAL.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MvvmExample.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime EntranceDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public Address Address { get; set; }
    }
}