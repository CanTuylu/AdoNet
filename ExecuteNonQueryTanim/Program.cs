using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteNonQueryTanim
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tanim
            /*
             ExecuteReader() metoduyla Select sorgu cümlelerini çalıştırabiliyorken
             ExecuteNonQuery() Insert,Delete,Update sorgularının çalıştırabiliriz.
             */
            #endregion

            Console.WriteLine("Update edilecek EmployeeId yi girin");
            string girdi= Console.ReadLine();

            string connectionString = "Data Source=.;Initial Catalog=NORTHWND;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE Employees SET FirstName='xxx' WHERE EmployeeID="+girdi;
            command.Connection = connection;

            connection.Open(); //Baglanti acilir.
            int donen = command.ExecuteNonQuery();
            if(donen>0)
                Console.WriteLine("Update islemi gerceklesti");
            connection.Close();

        }
    }
}
