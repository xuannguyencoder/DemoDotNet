using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Employee : Person
    {
        public string ID { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public Employee(string ID, string Name, int Age, string Address, int Salary, string Position) : base(Name, Age, Address)
        {
            this.ID = ID;
            this.Salary = Salary;
            this.Position = Position;
        }
        public override string ToString()
        {
            return string.Format("Ma NV: {0}, ten: {1}, tuoi: {2}, dia chi: {3}, luong: {4}, chuc vu: {5}", ID, Name, Age, Address, Salary, Position);
        }
    }
}
