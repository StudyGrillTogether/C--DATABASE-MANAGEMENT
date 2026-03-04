using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAY_2_GIT_EXERCISE_INSERT_DELETE_STUDENTS
{
    internal class Program
    {
        static string connectionString = "Server=localhost; Port=3306; Database=school_db; Uid=root; Pwd=BANKAI123";
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
                        Console.WriteLine("Enter Name: ");
                        string name=Console.ReadLine();

                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write("Enter Enrollment Date (YYYY-MM-DD): ");
                        string date = Console.ReadLine();

                        Console.Write("Enter Course ID: ");
                        int courseId = int.Parse(Console.ReadLine());
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
                        break;
                    case "2":
                        Console.WriteLine("Delete Student selected!");
                        Console.Write("Enter Student ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        try
                        {
                            using(MySqlConnection connection = new MySqlConnection(connectionString))
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

                        Console.WriteLine("\nDelete ID Entered: " + deleteId);
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
