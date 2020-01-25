using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise_25._01.Model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Country}";
        }
    }
}
