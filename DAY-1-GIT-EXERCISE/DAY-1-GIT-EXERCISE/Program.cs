using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DAY_1_GIT_EXERCISE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost; Port=3306; Initial Catalog=school_db; Uid=root; Pwd=BANKAI123";

            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();
                Console.WriteLine("Connection Opened Successfully!");

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM student", con);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["id"]);

                }
                reader.Close();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Database Erro: " + ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }

            finally
            {
                con.Close();
                Console.WriteLine("Connection Closed!");
            }
        }
    }
    
}
