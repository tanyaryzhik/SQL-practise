using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(10)]
        public string JobId { get; set; }

        [StringLength(35)]
        public string JobTitle { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
    }
}
