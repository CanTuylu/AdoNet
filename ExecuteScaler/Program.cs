using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteScaler
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             ExecuteScaler metodu matematisel işlemlerin sonucunu almak için kulalnılır
             */

            string connectionString = "Data Source=.;Initial Catalog=NORTHWND;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                //command.CommandText = "SELECT COUNT(*) FROM Products";
                command.CommandText = "SELECT SUM(UnitsInStock) FROM Products";
                connection.Open();

                int sonuc =(int)command.ExecuteScalar();
                Console.WriteLine("Sonuc:{0}",sonuc);

            }
        }
    }
}
