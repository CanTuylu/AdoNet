using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDbIleCalisma
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlConnection
            //OleDbConnection
            string connectinString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Northwind 2007.accdb;Persist Security Info = False;";
            using (OleDbConnection connection = new OleDbConnection(connectinString))
            {
                OleDbCommand command = new OleDbCommand();
                command.CommandText = "Select ProductName from Products";
                command.Connection = connection;
                connection.Open();
                Console.WriteLine(connection.State);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("UrunAdi :{}",reader["ProductName"]);
                    }
                }
            }
        }
    }
}
