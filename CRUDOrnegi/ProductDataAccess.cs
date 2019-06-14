using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrnegi
{
    public class ProductDataAccess : IProductRepo
    {
        IDbConnection connection;
        IDbCommand command;
        List<IDbDataParameter> myparameters;

        public ProductDataAccess(IDbConnection connect, IDbCommand com, List<IDbDataParameter> param)
        {
            connection = connect;
            command = com;
            myparameters = param;
        }
        public int Create(Product product)
        {
            myparameters[0].ParameterName = "@CategoryId";
            myparameters[0].Value = product.CategoryId;

            myparameters[1].ParameterName = "@ProductName";
            myparameters[1].Value = product.ProductName;

            myparameters[2].ParameterName = "@Price";
            myparameters[2].Value = product.Price;

            myparameters[3].ParameterName = "@Stok";
            myparameters[3].Value = product.UnitInStock;
            foreach (var item in myparameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = "Insert into Products " +
                "(CategoryID,ProductName,UnitPrice,UnitsInStock) values " +
                "(@CategoryId,@ProductName,@Price,@Stok)";
            command.Connection = connection;
            connection.Open();
            int effected = command.ExecuteNonQuery();
            connection.Close();
            command.Parameters.Clear();
            return effected;
        }

        public int Delete(int productId)
        {
            myparameters[0].ParameterName = "@ProductId";
            myparameters[0].Value = productId;

            command.Parameters.Add(myparameters[0]);
            command.CommandText = "DELETE from Products where ProductID=@ProductId";
            connection.Open();
            int ret = command.ExecuteNonQuery();
            connection.Close();
            command.Parameters.Clear();
            return ret;
        }

        public Product Select(int Id)
        {
            Product pr = null;
            myparameters[0].ParameterName = "@ProductId";
            myparameters[0].Value = Id;
         
            command.Parameters.Add(myparameters[0]);
            command.CommandText = "select ProductID,ProductName,UnitsInStock,UnitPrice from Products where ProductID=@ProductId";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    pr =new Product()
                    {
                        ProductId = (int)reader[0],
                        ProductName = (string)reader[1],
                        UnitInStock = (short)reader[2],
                        Price = (decimal)reader[3]
                    };
                }
            }
            connection.Close();
            command.Parameters.Clear();
            return pr;
        }

        public List<Product> SelectAll(string commandText, int kosulId)
        {
            var productList = new List<Product>();

            myparameters[0].ParameterName = "@CategoryId";
            myparameters[0].Value = kosulId;
            foreach (var item in myparameters)
            {
                command.Parameters.Add(item);
            }

            command.CommandText = commandText;
            command.Connection = connection;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    productList.Add(new Product()
                    {
                        ProductId = (int)reader[0],
                        ProductName = (string)reader[1],
                        UnitInStock = (short)reader[2],
                        Price = (decimal)reader[3]
                    });
                }
            }
            connection.Close();
            command.Parameters.Clear();
            return productList;
        }

        public int Update(Product product)
        {
            myparameters[0].ParameterName = "@ProductId";
            myparameters[0].Value = product.ProductId;

            myparameters[1].ParameterName = "@ProductName";
            myparameters[1].Value = product.ProductName;

            myparameters[2].ParameterName = "@Price";
            myparameters[2].Value = product.Price;

            myparameters[3].ParameterName = "@Stok";
            myparameters[3].Value = product.UnitInStock;
            foreach (var item in myparameters)
            {
                command.Parameters.Add(item);
            }
            
            command.CommandText = "Update Products set ProductName=@ProductName,UnitPrice=@Price,UnitsInStock=@Stok where ProductID=@ProductId";
            command.Connection = connection;
            connection.Open();
            int effected = command.ExecuteNonQuery();
            connection.Close();
            command.Parameters.Clear();
            return effected;
        }
    }
}
