using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class MovieCast
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string Role { get; set; }
    }
}
