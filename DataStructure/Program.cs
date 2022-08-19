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
            //OOP();
            Dictionary<string, Student> dic = new Dictionary<string, Student>()
            {
                {"1", new Student("SV001", "Nguyen Thanh Xuan", 21, "Tra Vinh", "Cong nghe thong tin")}
            };
            Student student2 = new Student("SV002", "Truong Quoc Thai", 22, "Tra Vinh", "Cong nghe thong tin");
            Student student3 = new Student("SV003", "Nguyen Minh Thu", 21, "Tra Vinh", "Cong nghe thong tin");
            dic.Add("2", student2);
            dic.Add("3", student3);

            //set value by key
            dic["2"] = new Student("SV002", "Truong Quoc Thoai", 22, "Tra Vinh", "Cong nghe thong tin");

            //remove by key
            dic.Remove("1");

            string key = "2";
            //Kiểm tra tồn tại bởi key
            if (dic.ContainsKey(key))
            {
                Console.WriteLine("Ton tai key {0} trong Dictionary", key);
            }
            KeyValuePair<string, Student> keyValueStudent = new KeyValuePair<string, Student>("3", student3);
            if (dic.Contains(keyValueStudent))
            {
                Console.WriteLine("Ton tai key {0} trong Dictionary", keyValueStudent.Key);
            }

            foreach (KeyValuePair<string, Student> item in dic)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value.ToString());
            }
            Console.WriteLine("So luong phan tu: " + dic.Count);
            dic.Clear();
            Console.Read();
        }
        public static void OOP()
        {

            Student student = new Student("110119127", "Nguyen Thanh Xuan", 22, "Tra Vinh", "Cong nghe thong tin");
            Employee employee = new Employee("NV001", "Truong Quoc Thai", 22, "Tra Vinh", 25000000, "Truong phong");
            Console.WriteLine(student.ToString());
            Console.WriteLine(employee.ToString());
            Console.Read();
        }
    }
}
