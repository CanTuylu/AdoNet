using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrnegi
{
    //public class AccessProductDataAccess : IProductRepo
    //{
    //    public int Create()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Delete()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Product Select(int Id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Product> SelectAll(int kosulId)
    //    {
    //        var productList = new List<Product>();
    //        string connectionString = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
    //        using (var connection = new OleDbConnection(connectionString))
    //        {
    //            OleDbCommand command = new OleDbCommand();
    //            command.Parameters.AddWithValue("@CategoryId", kosulId);
    //            command.CommandText = "Select ProductID,ProductName,UnitsInStock,UnitPrice from Products where CategoryID=@CategoryId";
    //            command.Connection = connection;
    //            connection.Open();

    //            using (var reader = command.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {

    //                    productList.Add(new Product()
    //                    {
    //                        ProductId = (int)reader["ProductID"],
    //                        ProductName = (string)reader["ProductName"],
    //                        Price = (decimal)reader["UnitPrice"],
    //                        UnitInStock = (short)reader["UnitsInStock"]
    //                    });
    //                }
    //            }

    //        }
    //        return productList;
    //    }

    //    public int Update()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
