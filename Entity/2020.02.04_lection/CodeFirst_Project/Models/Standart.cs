using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst_Project.Models
{
    public class Standart
    {
        public int StandartId { get; set; }
        public string StandartName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
