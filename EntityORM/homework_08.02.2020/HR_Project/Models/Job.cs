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
        [MaxLength(10)]
        public string JobId { get; set; }

        [MaxLength(35)]
        public string JobTitle { get; set; }

        public decimal MaxSalary { get; set; }

        public decimal MinSalary { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}