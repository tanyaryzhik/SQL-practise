using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [MaxLength(30)]
        public string DepartmentName { get; set; }

        public int ManagerId { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}