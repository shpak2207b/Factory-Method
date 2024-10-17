using Factory_Method;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Program
{
    
    public class Class_1
    {
        

        public int Id { get; set; }
        public virtual void Write()
        {
            
        }
        public static Class_1 Read(string line)
        {
            string[] parts = line.Split(',');
            if (parts[0] == "Student")
            {
                return Student.Read(parts);
            }
            else if (parts[0] == "Teacher")
            {
                return Teacher.Read(parts);
            }
            else if (parts[0] == "Course")
            {
                return Course.Read(parts);
            }
            else
            {
                throw new Exception("error");
            }
        }
    }
    public abstract class Class
    {
        public static Student CreateStudent(int id, string name)
        {
            return new Student(id, name);
        }

        public static Teacher CreateTeacher(int id, int experience, string name)
        {
            return new Teacher(id, experience, name);
        }

        public static Course CreateCourse(int id, string name, int teacherId)
        {
            return new Course(id, name, teacherId);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            


            Student student1 = Class.CreateStudent(1, "студент 1");
            Student student2 = Class.CreateStudent(2, "студент 2");

            Teacher teacher1 = Class.CreateTeacher(1, 5, "учитель 1");
            Teacher teacher2 = Class.CreateTeacher(2, 2, "учитель 2");

            Course course1 = Class.CreateCourse(324, "course1", teacher1.Id);

            student1.Courses.Add(course1.Id); student2.Courses.Add(course1.Id);

            course1.Students.Add(student1.Id); course1.Students.Add(student2.Id);

            teacher1.Courses.Add(course1.Id); teacher2.Courses.Add(course1.Id); 

            student1.Write();
            student2.Write();
            teacher1.Write();
            teacher2.Write();
            course1.Write();

            List<Class_1> objects = new List<Class_1>();
            using (StreamReader reader = new StreamReader("data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    objects.Add(Class_1.Read(line));
                }
            }
            
            foreach (Class_1 obj in objects)
            {
                if (obj is Student student)
                {
                    Console.WriteLine($"Имя: {student.Name}, ID: {student.Id}, Курсы: {string.Join(", ", student.Courses)}");
                }
                else if (obj is Teacher teacher)
                {
                    Console.WriteLine($"Имя: {teacher.Name}, ID: {teacher.Id}, Опыт: {teacher.Exp}, Курсы: {string.Join(", ", teacher.Courses)}");
                }
                else if (obj is Course course)
                {
                    Console.WriteLine($"Название: {course.Name}, ID: {course.Id}, Преподаватель: {course.Teacher_Id}, Студенты: {string.Join(", ", course.Students)}");
                }
            }
        }
        

    }
}
