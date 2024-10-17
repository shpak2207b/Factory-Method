using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class Teacher : Class_1
    {
        public int Exp { get; set; }
        public string Name { get; set; }
        public List<int> Courses { get; set; } = new List<int>();

        public Teacher(int id, int exp, string name)
        {
            Id = id;
            Exp = exp;
            Name = name;
            
        }
        public override void Write()
        {
            using (StreamWriter sw = new StreamWriter("data.txt", true))
            {
                sw.WriteLine($"Teacher, Id: {Id}, Experience: {Exp}, Name: {Name}, Courses: {string.Join("; ", Courses)}");
            }
        }
        public static Teacher Read(string[] parts)
        {
            int id = int.Parse(parts[1].Split(':')[1]);
            int exp = int.Parse(parts[2].Split(':')[1]);
            string name = parts[3].Split(':')[1];
            List<int> courses = new List<int>();
            string coursesStr = parts[4].Trim().Split(':')[1];
            foreach (string courseStr in coursesStr.Split(';'))
            {
                courses.Add(int.Parse(courseStr.Trim()));
            }
            return new Teacher(id, exp, name) { Courses = courses };
        }
    }
}
