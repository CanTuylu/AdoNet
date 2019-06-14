using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteReader
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tanim
            /*
             Execute Reader database deki tablo veya tablolardan birşeyler okur, yani bir select (sorgu) sql komutunun sonucun dbden almak için ExecuteReader() metodunu kullanırız.
             Bu metod .net framework deki SqlCommand sınıfında bulunur.
             Bu metod SqlDataReader tipinde bir nesne geri döndürür.
             */
            /*
            1-Once connection string belirlenir.
            2-SqlConnection nesnesini oluştururuz ve buna connectionstringi atarız
            3-Sorgu tanimlanir. (select * from tabloadi)
            4-ExecuteReader() calistırılır.
            5-ExecuteReader() sonucunda oluşan SqlDataReader nesnesi while ile Read() metodu false olana kadar gezilir ve satırlar okunur.
            6-Connection kapatılır.
            7-Reader kapatilir.
            */
            #endregion

            string connectionString = "Data Source=.;Initial Catalog=NORTHWND;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            //Sorgu tanimlamasi icin yine .net frameworkun SqlCommand sinifini kullaniriz.
            string sorgu = "SELECT * FROM [Products]";
            SqlCommand command = new SqlCommand();
            command.CommandText = sorgu;
            command.Connection = connection;

            connection.Open(); //baglanti acilir.

            SqlDataReader reader = command.ExecuteReader(); //komutu çalıştırırı ver SqlDataReader tipinde bir sonuç geri döndürür. bu sonucun neler olduğunu anlayabilmek için reader nesnesinin Read() metodunu kullanmamız gerekir.

            bool kayitVarmi = reader.Read();
            /*
             Read() metodundan donen sonuca göre yani read false olana kadar reader nesnesini bir loop da dönmem gerekir ki tüm reader nesnesine gelen verileri alabileyim.
             */
            //object t = reader[5];
            while (reader.Read())
            {
                string productName = (string)reader[1];
                string quantity = (string)reader["QuantityPerUnit"];
                decimal price = (decimal)reader["UnitPrice"];
                Console.WriteLine($"Ürün Adı:{productName}\nMiktar:{quantity}\nFiyat:{price}");
            }
            //Ilk 5 kayiti okumak icin
            //int counter = 0;
            //while (counter < 5)
            //{
            //    reader.Read();
            //    Console.WriteLine(reader[1]);
            //    counter++;
            //}

            connection.Close(); //baglanti kapanir
            reader.Close();
        }
    }
}
