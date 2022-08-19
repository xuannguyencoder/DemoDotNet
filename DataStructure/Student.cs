using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Student : Person
    {
        public string ID { get; set; }
        public string Major { get; set; }
        public Student(string ID, string Name, int Age, string Address, string Major) : base(Name, Age, Address)
        {
            this.ID = ID;
            this.Major = Major;
        }
        public override string ToString()
        {
            return string.Format("Ma SV: {0}, ten: {1}, tuoi: {2}, dia chi: {3}, chuyen nganh: {4}", ID, Name, Age, Address, Major);
        }
    }
}
