using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [MaxLength(25)]
        public string StreetAddress { get; set; }

        [MaxLength(12)]
        public string PostalCode { get; set; }

        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(12)]
        public string MyPropStateProvinceerty { get; set; }

        [MaxLength(2)]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}