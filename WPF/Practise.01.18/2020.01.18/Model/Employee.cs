using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._01._18.Model
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string HireDate { get; set; }

        public bool IsManager { get; set; }

        public static int counter = 0;
    }
}
