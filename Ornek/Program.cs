using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeleMapleme
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;


            using (var connection = new SqlConnection(connectionString))
            {
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
                        //Mapping, tablodan gelen verinin modele (domain nesnesine) atanmasi
                        Category cat = new Category();
                        cat.CategoryId = categoryId;
                        cat.CategoryName = categoryName;
                        cat.Description = categoryDesc;
                        Console.WriteLine(cat);
                        //Console.WriteLine(categoryName + " " + categoryDesc);

                        SqlCommand command2 = new SqlCommand();
                        command2.CommandText = "SELECT ProductName,UnitPrice FROM [Products] where CategoryID=" + categoryId.ToString();
                        command2.Connection = connection;

                        using (var reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productName = (string)reader["ProductName"];
                                decimal unitPrice = (decimal)reader["UnitPrice"];
                                Product pr = new Product();
                                pr.ProductName = productName;
                                pr.Price = unitPrice;

                                Console.WriteLine(pr);
                            }
                        }
                        Console.WriteLine("-----------------------------");
                    }
                }
            }
        }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{CategoryName} {Description}";
        }
    }

    class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{ProductName} {Price}";
        }
    }
}
