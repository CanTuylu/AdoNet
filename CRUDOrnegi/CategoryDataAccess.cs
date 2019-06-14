using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrnegi
{
    public class CategoryDataAccess : ICategoryRepo
    {
        IDbConnection connection;
        IDbCommand command;
        IDbDataParameter parameter;

        public CategoryDataAccess(IDbConnection connect, IDbCommand com, IDbDataParameter param)
        {
            connection = connect;
            command = com;
            parameter = param;
        }
        public CategoryDataAccess(IDbConnection connect, IDbCommand com)
        {
            connection = connect;
            command = com;
             
        }
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

            List<Category> catList = new List<Category>();
            command.CommandText = commandText;// 
            command.Connection = connection;
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Map
                    catList.Add(new Category()
                    {
                        //CategoryID = (int)reader["CategoryID"],
                        //CategoryName = (string)reader["CategoryName"],
                        //Description = (string)reader["Description"],
                        //Picture =(byte[])reader["Picture"]
                        CategoryID = (int)reader[0],
                        CategoryName = (string)reader[1],
                        Description = (string)reader[2],
                        Picture = (byte[])reader[3]
                    });
                }
            }
            connection.Close();

            return catList;
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
