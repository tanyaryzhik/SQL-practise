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

        [StringLength(25)]
        public string StreetAddress { get; set; }

        [StringLength(12)]
        public string PostalCode { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(12)]
        public string MyPropStateProvinceerty { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(2)]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}