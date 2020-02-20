﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Models
{
    public class MovieDirection
    {
        public int DirectorId { get; set; }

        public Director Director { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}