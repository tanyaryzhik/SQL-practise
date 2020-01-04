using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._04_practise.Model
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool IsNew { get; set; }

        private int counter;

        public EntityBase()
        {
            this.Id = this.counter++;
        }

        public void Save()
        {
            this.IsNew = false;
        }
    }
}
