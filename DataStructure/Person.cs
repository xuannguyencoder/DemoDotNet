using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Person(string Name, int Age, string Address)
        {
            this.Name = Name;
            this.Age = Age;
            this.Address = Address;
        }
    }
}
