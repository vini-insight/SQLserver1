using System;
using System.Data.SqlClient;
using System.Text;

namespace SQLserver1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Getting Connection ...");

            // var datasource = @"DESKTOP-PC\SQLEXPRESS";//your server
            // var database = "Students"; //your database name
            // var username = "sa"; //username of server to connect
            // var password = "password"; //password

            // //your connection string 
            // string connString = @"Data Source=" + datasource + ";Initial Catalog="
            //             + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            string connString = @"Server=localhost\SQLEXPRESS;Database=nodejs;Trusted_Connection=True;";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);           

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");

                //create a new SQL Query using StringBuilder
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("INSERT INTO students (name, email, class) VALUES ");
                strBuilder.Append("(N'Harsh', N'harsh@gmail.com', N'Class X'), ");
                strBuilder.Append("(N'Ronak', N'ronak@gmail.com', N'Class X') ");

                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
                {
                    command.ExecuteNonQuery(); //execute the Query
                    Console.WriteLine("Query Executed.");
                }

                strBuilder.Clear(); // clear all the string

                //create a new SQL Query using StringBuilder
                
                //add Query to update to Student_Details table
                strBuilder.Append("UPDATE students SET class = 'idontnow' WHERE name = 'Harsh'");
                
                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
                {                   
                    int rowsAffected = command.ExecuteNonQuery(); //execute query and get updated row count
                    Console.WriteLine(rowsAffected + " row(s) updated");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
