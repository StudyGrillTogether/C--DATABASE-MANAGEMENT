using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DAY_3_PRACTICE
{
    internal class Program
    {
        static string connectionString = "Server=localhost; Port=3306; Database=school_db; Uid=root; Pwd=BANKAI123";
        static void AddStudent()
        {
            Console.WriteLine("Add Student Selected");
            Console.WriteLine("Enter Name: ");
            string name=Console.ReadLine();

            Console.WriteLine("Enter age: ");
            int age=int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Enrollment Date:");
            string date=Console.ReadLine();

            Console.WriteLine("Enter Course ID: ");
            int courseId=int.Parse(Console.ReadLine());

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO student(name, age, enrollment_date, course_id) VALUES (@name, @age, @date, @courseId)";
                    using(MySqlCommand cmd=new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@courseId", courseId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("\n" + rowsAffected + " row(s) inserted successfully!");
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
            Console.WriteLine("\nStudent Details Entered:");
            Console.WriteLine("Name: " + name + " | Age: " + age + " | Date: " + date + " | Course ID: " + courseId);
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\n===== Student Menu =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Add Student selected!");
                        break;
                    case "2":
                        Console.WriteLine("Delete Student selected!");
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }
            }
        }
    }
}
