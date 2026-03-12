using System;
using System.Collections.Generic;
using System.Linq;

namespace DAY_4_PRACTICE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Ali",    Age = 20, Course = "Math" },
                new Student { Id = 2, Name = "Sara",   Age = 17, Course = "Science" },
                new Student { Id = 3, Name = "John",   Age = 22, Course = "Math" },
                new Student { Id = 4, Name = "Ayesha", Age = 15, Course = "English" },
                new Student { Id = 5, Name = "Ravi",   Age = 20, Course = "Science" },
            };

            var adults = students.Where(s => s.Age > 18);
            foreach ( var student in adults)
            {
                Console.WriteLine($"{student.Name} - {student.Age} - {student.Course}");
            }
            var course_math = students.Where(s => s.Course == "Math");
            foreach ( var student in course_math)
            {
                Console.WriteLine($"{student.Name}={student.Course}");
            }
            var teens = students.Where(s => s.Age < 18);
            foreach (var student in teens)
            {
                Console.WriteLine($"{student.Name} - {student.Age} - {student.Course}");
            }

            //sort students by age-younger first

            Console.WriteLine("======OrderBy=======");
            var sorted=students.OrderBy(s => s.Age);
            foreach(var student in sorted)
            {
                Console.WriteLine($"{student.Name}-{student.Age}");
            }

            //in descending that is older first
            var sorteds=students.OrderByDescending(s => s.Age);
            Console.WriteLine("IN DESCENDING ORDER");
            foreach (var student in sorteds)
            {
                Console.WriteLine($"{student.Name}-{student.Age}");
            }
        }
    }

    
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
    }
}