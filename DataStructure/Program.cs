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
            //Dictionary();
            LinkedList<Student> students = new LinkedList<Student>();
            students.AddLast(new Student("SV001", "Truong Quoc Thai", 22, "Tra Vinh", "Cong nghe thong tin"));
            students.AddLast(new Student("SV002", "Nguyen Truc Ngoc", 22, "Tra Vinh", "Cong nghe thong tin"));
            students.AddLast(new Student("SV003", "Cao Thanh C", 22, "Tra Vinh", "Cong nghe thong tin"));
            students.AddLast(new Student("SV004", "Tran Anh Tai", 22, "Tra Vinh", "Cong nghe thong tin"));

            //Add đầu danh sách 
            var studentNode = students.AddFirst(new Student("SV005", "Nguyen Thanh Xuan", 21, "Tra Vinh", "Cong nghe thong tin"));
            //Add trước vị trí studentNode
            students.AddBefore(studentNode, new Student("SV006", "Tran Van Nam", 21, "Ben Tre", "Cong nghe thong tin"));

            //Remove phần tử đầu
            students.RemoveFirst();
            //Remove phần tử cuối
            students.RemoveLast();
            //Remove by ID
            string ID = "SV005";
            LinkedList<Student> students2 = new LinkedList<Student>(students);
            foreach (var s in students2)
            {
                if (s.ID == ID)
                {
                    students.Remove(s);
                    break;
                }
            }
            //Lấy phần tử theo vị trí
            int index = 1;
            var student = students.ElementAt(index);
            Console.WriteLine("Phan tu vi tri {0}: " + student.ToString(), index);

            //Array
            Student[] arryStudent = new Student[students.Count()];
            students.CopyTo(arryStudent, 0);

            Student student1 = new Student("SV002", "Nguyen Truc Ngan", 22, "Tra Vinh", "Cong nghe thong tin");
            //set value cho phần tử theo vị trí
            arryStudent.SetValue(student1, 1);
            //get value của phần tử theo vị trí
            var student3 = arryStudent.GetValue(1);
            Console.WriteLine("Lay ra theo vi tri 1: " + student3.ToString());

            foreach (var item in arryStudent)
            {
                Console.WriteLine(item.ToString());
            }
            students.Clear();
            Console.Read();
        }
        public static void Dictionary()
        {
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
