using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int Year { get; set; }
        public int Time { get; set; }
        public string Language { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string CountryOfRelease { get; set; }
    }
}
