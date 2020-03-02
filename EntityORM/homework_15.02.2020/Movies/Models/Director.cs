using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        public string DirFirstName { get; set; }

        public string DirLastName { get; set; }

        public ICollection<MovieDirection> MovieDirections { get; set; }
    }
}