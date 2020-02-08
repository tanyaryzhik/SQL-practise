using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirst_Project.Models
{
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
       
        public string Country { get; set; }

        
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
