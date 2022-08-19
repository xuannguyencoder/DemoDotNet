using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("110119127", "Nguyen Thanh Xuan", 22, "Tra Vinh", "Cong nghe thong tin");
            Employee employee = new Employee("NV001", "Truong Quoc Thai", 22, "Tra Vinh", 25000000, "Truong phong");
            Console.WriteLine(student.ToString());
            Console.WriteLine(employee.ToString());
            Console.Read();
        }
    }
}
