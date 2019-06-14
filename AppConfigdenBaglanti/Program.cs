using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigdenBaglanti
{
    class Program
    {
        static void Main(string[] args)
        {
            //Baglanti cumlesini AppConfig den almak icin ConfigurationManager isimli classi kullanmamız gerekir.
            //Referans olarak System.Configuration icindeki ConfigurationManager sınıfı kullanılır.Bunu referans ile eklemekl gerekir.
            //string connectionString = "";
            //ConnectionStringSettingsCollection constrings = ConfigurationManager.ConnectionStrings;
            //foreach (ConnectionStringSettings item in constrings)
            //{
            //    connectionString= item.ConnectionString;
            //}

            string constring = ConfigurationManager.ConnectionStrings["benimSqlBaglantim"].ConnectionString;
            SqlConnection connection = new SqlConnection(constring);
            try
            {
                connection.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(connection.State);
            connection.Close();
        }
    }
}
