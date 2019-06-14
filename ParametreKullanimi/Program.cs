using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametreKullanimi
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Güvenlik açısından, db ye göndereceğimiz sorgularda eğer ki
             parametreleri direk olarak CommandTexte gömersek sıkıntılar çıkartır
             Mesela SqlInjection. 
             Bunun üstesinden gelmek için SqlCommand nesnemizin CommandTextini
             belirlerken, Paramters koleksiyonunun AddWithValue() metodunu kullanarak
             sorguya gömeceğimiz parametereleri daha güvenli halde tutabiliriz.
             */
            Console.WriteLine("PersonelId yi girin:");
            int id = int.Parse(Console.ReadLine());
            string connectionString = "Data Source=.; Initial Catalog=NORTHWND; Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand();
                command.CommandText = "Select FirstName,LastName from Employees where EmployeeID=@Id";
                command.Parameters.AddWithValue("@Id", id);
                command.Connection = connection;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        Console.WriteLine("CalisanIsmi:{0}",firstName);
                        Console.WriteLine("CalisanSoyIsmi:{0}", lastName);
                    }
                }
            }

        }
    }
}
