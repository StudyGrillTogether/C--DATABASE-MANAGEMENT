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

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("INVALID AGE:");
                return;
            }

            Console.WriteLine("Enter Enrollment Date (YYYY-MM-DD): ");
            string date = Console.ReadLine();

            Console.WriteLine("Enter Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Invalid Course Id");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO student(name, age, enrollment_date, course_id) VALUES (@name, @age, @date, @courseId)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@courseId", courseId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine("\n" + rowsAffected + " row(s) inserted successfully!");

                        Console.WriteLine("\nStudent Details Entered:");
                        Console.WriteLine("Name: " + name + " | Age: " + age + " | Date: " + date + " | Course ID: " + courseId);
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
                using (MySqlConnection connection = new MySqlConnection(connectionString))
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
                using (MySqlConnection connection = new MySqlConnection(connectionString))
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
                using (MySqlConnection connection = new MySqlConnection(connectionString))
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
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
        }
        static void Main(string[] args)
        {

            while (true)
            {
                ShowMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        AddStudent();
                        break;
                    case "2":

                        ViewStudents();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
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
