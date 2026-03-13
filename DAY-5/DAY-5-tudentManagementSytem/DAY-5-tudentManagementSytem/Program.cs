using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY_4_GIT_EXERCISE
{
    internal class Program
    {
        static void AddStudent()
        {
            Console.WriteLine("Enter Name: ");
            string name=Console.ReadLine();

            Console.WriteLine("Enter Age: ");
            if(!int.TryParse(Console.ReadLine(),out int age))
            {
                Console.WriteLine("INVALID AGE:");
                return;
            }

            Console.WriteLine("Enter Enrollment Date (YYYY-MM-DD): ");
            string date = Console.ReadLine();

            Console.WriteLine("Enter Course ID: ");
            if(!int.TryParse (Console.ReadLine(),out int courseId))
            {
                Console.WriteLine("Invalid Course Id");
                return;
            }
            Console.WriteLine("Enter your Email: ");
            string email = Console.ReadLine();

            try
            {
                using(MySqlConnection connection=new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    string query= "INSERT INTO student(name, age, enrollment_date, course_id,email) VALUES (@name, @age, @date, @courseId,@email)";
                    using(MySqlCommand cmd=new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@courseId", courseId);
                        cmd.Parameters.AddWithValue("@email", email);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("\n" + rowsAffected + " row(s) inserted successfully!");

                        Console.WriteLine("\nStudent Details Entered:");
                        Console.WriteLine("Name: " + name + " | Age: " + age + " | Date: " + date + " | Course ID: " + courseId+"|Email: "+ email);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }
        static void DeleteStudent()
        {

            Console.Write("Enter Student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Invalid ID");
                return;
            }
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    string query = "DELETE FROM student WHERE id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", deleteId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\n" + rowsAffected + " row(s) deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nNo student found with ID: " + deleteId);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }
        static void ViewStudents()
        {
            Console.WriteLine("\n=======Viewing Students========");
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
                                Console.WriteLine("ID: " + reader["id"] +
                            " | Name: " + reader["name"] +
                            " | Age: " + reader["age"] +
                            " | Enrollment Date: " + reader["enrollment_date"] +
                            " | Course ID: " + reader["course_id"]);
                            }
                        }

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
        }
        static void UpdateStudent()
        {
            Console.WriteLine("Enter Student Id TO Update:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID! please enter a number: ");
                return;
            }

            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your new age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("invalid age! Please enter a number");
                return;
            }
            Console.Write("Enter New Enrollment Date (YYYY-MM-DD)");
            string date = Console.ReadLine();

            Console.Write("Enter New Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseID))
            {
                Console.WriteLine("Invalid Course ID! Please Enter a Number ");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionstring))
                {
                    connection.Open();
                    string query = "UPDATE student SET name=@name,age=@age,enrollment_date=@date,course_id=@courseID WHERE id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@courseID", courseID);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            Console.WriteLine("\n" + rowsaffected + " row(s) updated successfully!");
                            Console.WriteLine("Name: " + name + " | Age: " + age + " | Course ID: " + courseID);
                        }
                        else
                        {
                            Console.WriteLine("\nNo student found with ID: " + id);
                        }

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }

        }
        static void ShowMenu()
        {
            Console.WriteLine("\n===== Student Menu =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5.Search by Name");
            Console.WriteLine("6.Filter By age");
            Console.WriteLine("7.Sort By Name");
            Console.WriteLine("8.Show Total Count");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");
        }
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string EnrollmentDate { get; set; }
            public int CourseId { get; set; }

            public string email { get; set; }
        }
        static string connectionstring = "Server=localhost; Port=3306; Database=school_db; Uid=root; Pwd=BANKAI123";

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
                                    CourseId = reader["course_id"] == DBNull.Value ? 0 : (int)reader["course_id"],
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

        static void SearchByName(List<Student> students)
        {
            Console.WriteLine("Enter THE name to search: ");
            string name=Console.ReadLine();
            var found = students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
            if (found != null)
            {
                Console.WriteLine($"Found! ID: {found.Id} | Name: {found.Name} | Age: {found.Age} | Email: {found.email}");
            }
            else
            {
                Console.WriteLine("STUDENT WITH THIS NAME NOT OFUND");
            }
        }

        
        static void FilterByAge(List<Student> students)
        {
                        
            bool run = true;
            while (run)
            {
                Console.WriteLine("====FILTER BY AGE======");
                Console.WriteLine("How do you want to filter");
                Console.WriteLine("1.Filter students OLDER than age");
                Console.WriteLine("2.Filter students YOUNGER than age");
                Console.WriteLine("3.Filter students by EXACT age");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Choose an option: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter AGE:");
                        if (!int.TryParse(Console.ReadLine(), out int older))
                        {
                            Console.WriteLine("enter a valid age !");
                            break;
                        }
                        var student = students.Where(s => s.Age > older);
                        foreach(var s in student)
                        {
                            Console.WriteLine($"Name:{s.Name}| Age:{s.Age}");
                        }
                        break;
                    case "2":
                        Console.Write("Enter AGE:");
                        if (!int.TryParse(Console.ReadLine(), out int younger))
                        {
                            Console.WriteLine("enter a valid age !");
                            break;
                        }
                        var YoungerStudents=students.Where(s=>s.Age < younger);
                        foreach (var s in YoungerStudents)
                        {
                            Console.WriteLine($"Name:{s.Name}| Age:{s.Age}");
                        }
                        break;
                    case "3":
                        Console.Write("Enter AGE:");
                        if (!int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.WriteLine("enter a valid age !");
                            break;
                        }
                        var Exactage = students.Where(s => s.Age == age);
                        foreach (var s in Exactage)
                        {
                            Console.WriteLine($"Name:{s.Name}| Age:{s.Age}");
                        }
                        break;
                    case "4":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

        }

        static void SortByName(List<Student> students)
        {
            Console.WriteLine("=====Sorting By Name=====");
            var student = students.OrderBy(s => s.Name);
            foreach(var s in student)
            {
                Console.WriteLine($" ID: {s.Id} | Name: {s.Name} | Age: {s.Age} | Email: {s.email}");
            }
        }

        static void ShowTotalCount(List<Student> students)
        {
            Console.WriteLine($"The Total count of students is :{students.Count}");
            Console.WriteLine($"Students older than 20: {students.Where(s => s.Age > 20).Count()}");
            Console.WriteLine($"Students younger than 18: {students.Where(s => s.Age < 18).Count()}");
        }
        static void Main(string[] args)
        {
            List<Student> students = LoadStudents();
            Console.WriteLine($"DATA LOADED OF STUDENTS:{students.Count}");           

            while (true)
            {
                ShowMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        AddStudent();
                        students=LoadStudents();
                        break;
                    case "2":
                        ViewStudents();                   
                        break;
                    case "3":
                        UpdateStudent();
                        students = LoadStudents();
                        break;
                    case "4":
                        DeleteStudent();
                        students = LoadStudents();
                        break;
                    
                    case "5":
                        SearchByName(students);
                        break;
                    case "6":
                        FilterByAge(students);
                        break;
                    case "7":
                        SortByName(students);
                        break;
                    case "8":
                        ShowTotalCount(students);
                        break;
                    case "9":
                        Console.WriteLine("GOODBYE");
                        return;
                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }
            }

        }
    }
}
