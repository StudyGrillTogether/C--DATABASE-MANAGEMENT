using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;

namespace DAY_2_PRACTICE_NONQUERY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String connectionString = "Data Source=localhost;port=3306;Initial Catalog=school_db;uid=root;pwd=BANKAI123";
            string StudentName = "sefoy";
            int age = 23;
            string EnrollMentDate = "2023-09-04";
            int courseid = 313;
            try
            {
                using(MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO student(name,age,enrollment_date,course_id) VALUES ('solan',20,'2023-09-01',302)", connection);
                    string query = "INSERT INTO student(name, age, enrollment_date, course_id) VALUES (@name, @age, @date, @courseId)";
                    using(MySqlCommand cmd1=new MySqlCommand(query, connection))
                    {
                        cmd1.Parameters.AddWithValue("@name", StudentName);
                        cmd1.Parameters.AddWithValue("@age", age);
                        cmd1.Parameters.AddWithValue("@date", EnrollMentDate);
                        cmd1.Parameters.AddWithValue("@courseID", courseid);

                        int rowsaffected1=cmd1.ExecuteNonQuery();
                        Console.WriteLine(rowsaffected1 + " row(s) inserted!");
                    }
                    //using parameters for finding student id
                    string query1 = "SELECT * FROM student WHERE id=@id";
                    using(MySqlCommand cmd1=new MySqlCommand(@query1, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", 5);
                        using(MySqlDataReader reader = cmd1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["name"].ToString());
                            }
                        }
                    }
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + "row(s) inserted");
                }                

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }

            finally
            {
                Console.WriteLine("Connection Closed!");
            }
        }
    }
}
