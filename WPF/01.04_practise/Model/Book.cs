using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._04_practise.Model
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public Language Language { get; set; }
        public bool IsRead { get; set; }
    }
}
