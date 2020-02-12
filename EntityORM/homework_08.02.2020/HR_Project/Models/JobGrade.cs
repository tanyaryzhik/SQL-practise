using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class JobGrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(2)]
        public string GradeLevel { get; set; }

        public decimal LowestSalary { get; set; }

        public decimal HighestSalary { get; set; }

    }
}
