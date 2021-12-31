using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDomain
{
    public class Car
    {
        //public Car()
        //{
        //    Humans = new HashSet<Human>();
        //}

        public int Id { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }

        public virtual ICollection<Human>? Humans { get; set; }
    }
}
