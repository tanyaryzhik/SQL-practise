using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class Country
    {
        [Key]
        [MaxLength(2)]
        public string CountryId { get; set; }

        [MaxLength(40)]
        public string CountryName { get; set; }

        public int RegionId { get; set; }

        public Region Region { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}