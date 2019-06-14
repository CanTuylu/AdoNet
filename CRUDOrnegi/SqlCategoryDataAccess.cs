using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrnegi
{
    public class SqlCategoryDataAccess : ICategoryRepo
    {
        public int Create()
        {
            return 0;
        }
         
        public int Delete()
        {
            throw new NotImplementedException();
        }

        public Category Select(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> SelectAll(string commandText,int? kosulId)
        {
            if (kosulId != null)
                return null;

            string connectinString = ConfigurationManager.ConnectionStrings["baglanti"].ConnectionString;
            List<Category> catList = new List<Category>();
            using (SqlConnection connection = new SqlConnection(connectinString))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT CategoryID,CategoryName,Description FROM Categories";
                command.Connection = connection;
                connection.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Map
                        catList.Add(new Category()
                        {
                            CategoryID = (int)reader["CategoryID"],
                            CategoryName = (string)reader["CategoryName"],
                            Description = (string)reader["Description"]
                        });
                    }
                }
            }
            return catList;
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
