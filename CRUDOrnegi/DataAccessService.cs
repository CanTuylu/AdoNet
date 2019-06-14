using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrnegi
{
    public class DataAccessService
    {
        ICategoryRepo catRepo;
        IProductRepo proRepo;
        public DataAccessService(ICategoryRepo cat)
        {
            catRepo= cat;
        }
        public DataAccessService(IProductRepo pro)
        {
            proRepo = pro;
        }
        public DataAccessService(ICategoryRepo cat,IProductRepo pro)
        {

        }
        public List<Category> GetAllCategories(string commandText)
        {
            return catRepo.SelectAll(commandText);
        }

        public List<Product> GetProductsByCategory(string commandText,int categoryId)
        {
            return proRepo.SelectAll(commandText,categoryId);
        }

        public int AddProduct(Product product)
        {
            return proRepo.Create(product);
        }

        public int DeleteProduct(int productId)
        {
            return proRepo.Delete(productId);
        }
    }
}
