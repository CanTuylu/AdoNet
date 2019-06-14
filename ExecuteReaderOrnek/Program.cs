using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//MARS
namespace ExecuteReaderOrnek
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Soru
            /*
             KategoriAdi
                    -Urun1
                    -Urun2
                    -Urun3
             KategoriAdi2
                    -Urun4
                    -Urun5
             */
            //Tablodaki kategoriler ve o kategoriye ait urunleri yazdiralim.
            #endregion

            string connectionString = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;

            var connection = new SqlConnection(connectionString);
            var connection2 = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT CategoryID,CategoryName,Description FROM [Categories]";
            command.Connection = connection;
            connection.Open();

            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int categoryId = (int)dataReader["CategoryID"];
                    string categoryName = (string)dataReader["CategoryName"];
                    string categoryDesc = (string)dataReader["Description"];
                    Console.WriteLine(categoryName + " " + categoryDesc);

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = "SELECT ProductName,UnitPrice FROM [Products] where CategoryID=" + categoryId.ToString();
                    command2.Connection = connection2;
                    connection2.Open();
                    using (var reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = (string)reader["ProductName"];
                            decimal unitPrice = (decimal)reader["UnitPrice"];
                            Console.WriteLine(productName + " " + unitPrice);
                        }
                    }
                    connection2.Close();
                    Console.WriteLine("-----------------------------");
                }
            }
            connection.Close();

        }
    }
}
