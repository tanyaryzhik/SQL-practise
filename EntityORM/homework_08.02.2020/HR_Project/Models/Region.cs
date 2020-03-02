using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR_Project.Models
{
    public class Region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegiontId { get; set; }

        [MaxLength(25)]
        public string RegionName { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}