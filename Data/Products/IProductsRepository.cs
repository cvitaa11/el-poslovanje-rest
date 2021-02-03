using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Products
{
    public interface IProductsRepository
    {
        IEnumerable<Models.Products> GetAllProducts(string productName);
        Models.Products GetProductById(int id);
        void CreateProduct(Models.Products model);
        void UpdateProduct(Models.Products model);
        void DeleteProduct(Models.Products model);
    }
}
