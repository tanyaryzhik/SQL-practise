using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst_Project.Models
{
    [Table("StudentMaster", Schema = "Admin")]
    public class Student
    {
       
        public int StudentId { get; set; }
        public string Name { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        [ForeignKey("Standart")]
        public int StandartRefId { get; set; }
        public Standart Standart { get; set; }
    }
}
