using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaglantiIslemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Bir database ile iş yapmak için önce databasein nerede olduğunu
             * uygulamamıza bildirmemiz gerekir. Bu db local de olduğu gibi bir
             * serverdada olabilir.
             * .Net Framework bize mssql ile iletişime geçebilmek için, SqlClient adında bir class sunmuştur.
             */
            SqlConnection connection = new SqlConnection();
            string connectionString = "Data Source=.;Initial Catalog=NORTHWND;Integrated Security=True";
            /*
             ConnectionString:
             Data Source=>database adresi (sqlserver yada Oracle yada Access)
             Initial Catalog => Database adi
             Integrated Security=> true yada false, true olmasi demek baglantının herhangi bir username ve password a ihtiyaç duymaması demek
             ConnectionString SqlConnection constructorina verilebilir yada
             örneklediğimiz nesnenin ConnectionString özelliğine atanabilir.
             */
            connection.ConnectionString = connectionString;

            BaglantiKontrol(connection);

            /*
             Connection string belirlendikten sonra, connection açılır.
             */
            Console.WriteLine("Baglanti Aciliyor");
            connection.Open(); //dbye connection açar.
            BaglantiKontrol(connection);
            /*
             * Open ile connection açıldıktan sonra işlemlerimizi yaptıktan sonra mutlaka close yani kapatılmalıdır.
               Çünkü database bir external resource dur. Ve .net GC collector 
               müdahele edemiyor ve silemiyor.
               Dolayısıyle bağlantı hep açık kalarak kaynakları tüketiyor.
             */
            connection.Close();

            /*
             Connectionı kapatmak için Close metodu yerine using keywordünü kullanabilir, using IDisposable interfaceini implemente eden her sınıfa uygulanır
             */
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();
                //Burada database ile ilgili isleri yapabiliriz.
                //Sorgular, crud islemleri vs.
            }
        }

        private static void BaglantiKontrol(SqlConnection connection)
        {
            //Console.WriteLine("Bağlantı durumu:{0}", connection.State);
            if (connection.State == ConnectionState.Closed)
                Console.WriteLine("Bağlantı yok");
            else if (connection.State == ConnectionState.Open)
                Console.WriteLine("Bağlantı var");
        }
    }
}
