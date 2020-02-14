using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class JobHistory
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [StringLength(10)]
        public string JobId { get; set; }

        public Job Job { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
