using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Book
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }

    //public enum Genre
    //{
    //    Classic = 0,
    //    Fiction = 1,
    //    Fantasy = 2,
    //    Detective = 3,
    //    Thriller = 4,
    //    Novel = 5,
    //    Lyrics = 6
    //}
}
