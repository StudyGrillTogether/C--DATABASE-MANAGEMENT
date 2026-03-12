using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;

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
            Console.WriteLine("=====using ANY()======");

            bool hasAdults = students.Any(s => s.Age >= 18);
            Console.WriteLine(hasAdults);

            bool isInEnglish = students.Any(s => s.Course == "English");
            Console.WriteLine(isInEnglish);

            bool over25=students.Any(s => s.Age > 25);
            if (over25)
            {
                Console.WriteLine("student over 25 is there");
            }
            else
            {
                Console.WriteLine("Student over 25 is not present");
            }

            Console.WriteLine("=====using Select======");
            Console.WriteLine("=====FIRST WAY -EXTRACTING ONE PROPERTY======");
            var names = students.Select(s => s.Name);
            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("=====SECOND WAY -Create a new string by combining properties:======");
            var summaries = students.Select(s => $"{s.Name} is {s.Age} years old");
            foreach(var summary in summaries)
            {
                Console.WriteLine(summary);
            }
            Console.WriteLine("=====third WAY Chain with Where():======");

            var adultnames = students
                .Where(s => s.Age > 18)
                .Select(s => s.Name);
            foreach (var adultname in adultnames) { Console.WriteLine(adultname); }
            var summarie1s = students.Select(s => $"{s.Name} is {s.Course} has course");

            var scienceCourse = students
                .Where(s => s.Course == "Science")
                .Select(s => s.Name);
            foreach (var name in scienceCourse) { Console.WriteLine(name); }
            // Get names of adult students sorted alphabetically:
            var result1=students
                .Where(s=>s.Age>18)
                .OrderBy(s=>s.Name)
                .Select (s => s.Name);
            foreach (var name in result1)
            {
                Console.WriteLine(name);
            }

            //get the youngest math student

            var result2 = students
                .Where(s => s.Course == "Math")
                .OrderBy(s => s.Age)
                .FirstOrDefault();
            if (result2 != null)
                Console.WriteLine($"Youngest Math student: {result2.Name} - {result2.Age}");

            //check if any underage sceince students exist

            bool exists = students
                .Where(s => s.Course == "Science")
                .Any(s => s.Age < 18);
            if (exists)
                Console.WriteLine("There are underage Science students!");
            else
                Console.WriteLine("No underage Science students!");

            //formatted summary of all students sorted by age

            var result3 = students
                .OrderBy(s => s.Age)
                .Select(s => $"{s.Name}|age{s.Age}|course:{s.Course}");
            foreach(var line in result3)
            {
                Console.WriteLine(line);
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