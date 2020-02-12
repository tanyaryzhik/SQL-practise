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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(2)]
        public string CountryId { get; set; }

        [StringLength(40)]
        public string CountryName { get; set; }
        public int RegionId { get; set; }
    }
}
