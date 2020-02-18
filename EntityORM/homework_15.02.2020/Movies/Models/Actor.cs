using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
