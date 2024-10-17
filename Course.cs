using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public class Course : Class_1
    {
        public string Name { get; set; }
        public int Teacher_Id { get; set; }
        public List<int> Students { get; set; } = new List<int>();

        public Course(int id, string name, int teacher_Id)
        {
            Id = id;
            Name = name;
            Teacher_Id = teacher_Id;
            
        }
        public override void Write()
        {
            using (StreamWriter sw = new StreamWriter("data.txt", true))
            {
                sw.WriteLine($"Course, Id: {Id}, Name: {Name}, Teacher_Id: {Teacher_Id}, Students: {string.Join("; ", Students)}");
            }
        }
        public static Course Read(string[] parts)
        {



            int id = int.Parse(parts[1].Split(':')[1]);
            string name = parts[2].Split(':')[1];
            int teacher_Id = int.Parse(parts[3].Split(':')[1]);
            List<int> students = new List<int>();
            string studentsStr = parts[4].Trim().Split(':')[1];

            foreach (string x in studentsStr.Split(';'))
            {
                students.Add(int.Parse(x.Trim()));
            }

          
            return new Course(id, name, teacher_Id) { Students = students };
        }
    }
}
