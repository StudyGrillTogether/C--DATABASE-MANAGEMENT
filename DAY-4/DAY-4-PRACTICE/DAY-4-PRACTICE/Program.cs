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
            Console.WriteLine("=====SOrting by name======");
            var byName=students.OrderBy(s=>s.Name);
            foreach(var  s in byName)
            {
                Console.WriteLine($"{s.Name}");    
            }
            Console.WriteLine("=====Chaning with where======");
            var result = students
                .Where(s => s.Age > 18)
                .OrderBy(s => s.Name);
            foreach (var s in result)
            {
                Console.WriteLine($"{s.Name} - {s.Age}");
            }

            Console.WriteLine("=====using first or default======");
            var firstMath = students.FirstOrDefault(s => s.Course == "Math");
            Console.WriteLine(firstMath.Name);
            Console.WriteLine("=====using first or default======");
            var youngest = students.OrderBy(s => s.Age).FirstOrDefault();
            Console.WriteLine(youngest.Name+"is the first when ordered by age");
            Console.WriteLine("=====using first or default like above but in descending age======");
            var oldest=students.OrderByDescending(s=>s.Age).FirstOrDefault();
            Console.WriteLine($"the oldest is {oldest.Name} of age {oldest.Age}");

            var age99 = students.FirstOrDefault(s => s.Age == 99);
            if (age99 != null)
            {
                Console.WriteLine (age99.Name);
            }
            else
            {
                Console.WriteLine ("No such student with the age found");
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