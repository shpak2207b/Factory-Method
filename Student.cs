using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class Student : Class_1
    {
        public string Name { get; set; }
        public List<int> Courses { get; set; } = new List<int>();

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
           
        }
        public override void Write()
        {
            using (StreamWriter sw = new StreamWriter("data.txt", true))
            {
                sw.WriteLine($"Student, Id: {Id}, Name: {Name}, Courses: {string.Join("; ", Courses)}");
            }
        }
        public static Student Read(string[] parts)
        {
            int id = int.Parse(parts[1].Split(':')[1]);
            string name = parts[2].Split(':')[1];
            List<int> courses = new List<int>();
            string coursesStr = parts[3].Trim().Split(':')[1];
            foreach (string courseStr in coursesStr.Split(';'))
            {
                courses.Add(int.Parse(courseStr.Trim()));
            }
            return new Student(id, name) { Courses = courses };
        }


    }
}
