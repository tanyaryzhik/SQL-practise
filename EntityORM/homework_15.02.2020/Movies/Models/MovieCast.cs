﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class MovieCast
    {
        public int ActorId { get; set; }

        public Actor Actor { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public string Role { get; set; }
    }
}