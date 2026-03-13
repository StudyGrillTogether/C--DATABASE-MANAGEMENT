using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAY_4_GIT_EXERCISE
{
    internal class Program
    {
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string EnrollmentDate {  get; set; }
            public int CourseId {  get; set; }

            public string email {  get; set; }
        }
        static string connectionstring= "Server=localhost; Port=3306; Database=school_db; Uid=root; Pwd=BANKAI123";

        static List<Student> LoadStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    string query = "SELECT * FROM student";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student s = new Student
                                {
                                    Id = (int)reader["id"],
                                    Name = reader["name"].ToString(),
                                    Age = (int)reader["age"],
                                    EnrollmentDate = reader["enrollment_date"].ToString(),
                                    CourseId = reader["course_id"]==DBNull.Value?0: (int)reader["course_id"],
                                    email = reader["email"].ToString()
                                };
                                students.Add(s);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            return students;
        }
        static void Main(string[] args)
        {
            List<Student> students = LoadStudents();
            Console.WriteLine($"DATA LOADED OF STUDENTS:{students.Count}");


            var adults = students.Where(s => s.Age > 20);
            Console.WriteLine("=====sTUDENTS OLDER THAN 20 ARE");
            foreach (var s in adults)
            {

                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} | Age: {s.Age}");
            }
            var Sortemail = students.OrderBy(s => s.email);
            Console.WriteLine("=====Sorting students by email");
            foreach (var s in Sortemail)
            {
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} | Email:{s.email}");
            }

            Console.WriteLine("====Search By email=======");
            Console.WriteLine("Enter email to search");
            string searchEmail = Console.ReadLine();

            var found = students.FirstOrDefault(s => s.email == searchEmail);
            if (found != null)
            {
                Console.WriteLine($"Found! ID: {found.Id} | Name: {found.Name} | Age: {found.Age} | Email: {found.email}");
            }
            else
            {
                Console.WriteLine($"No student found with email: {searchEmail}");
            }

            Console.WriteLine("======Total Count of Students=====");
            Console.WriteLine(students.Count);

        }   
    }
}
