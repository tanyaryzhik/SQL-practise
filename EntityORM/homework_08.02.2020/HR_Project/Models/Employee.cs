using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [StringLength(25)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        [StringLength(10)]
        public string JobId { get; set; }

        public Job Job { get; set; }

        public decimal Salary { get; set; }

        public int CommissionPct { get; set; }

        public int ManagerId { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<JobHistory> JobHistories { get; set; }
    }
}