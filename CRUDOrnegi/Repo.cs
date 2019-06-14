using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//SqlSERVER, ACCESS 
namespace CRUDOrnegi
{
    public interface IProductRepo
    {
        int Delete(int productId);
        int Update(Product product);
        int Create(Product product);
        List<Product> SelectAll(string commandText,int kosulId);

        Product Select(int Id);
    }
    public interface ICategoryRepo
    {
        int Delete();
        int Update();
        int Create();
        List<Category> SelectAll(string commandText,int? kosulId=null );
        Category Select(int id);
    }
}
