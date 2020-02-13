﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst_Project.Models
{
    [Table("StudentMaster", Schema = "Admin")]
    public class Student
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public int CurrentGradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public virtual StudentAddress Address { get; set; }
        public virtual IList<StudentCourse> StudentCourses { get; set; }

        //[ForeignKey("Standart")]
        //public int StandartRefId { get; set; }
        //public Standart Standart { get; set; }
    }
}
