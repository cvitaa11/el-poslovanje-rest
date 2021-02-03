using CBBStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Products
{
    public class ProductsRepository : IProductsRepository
    {
        #region fields
        private CBBStoreContext Context => new CBBStoreContext(_config);
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public ProductsRepository(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region implementation
        public IEnumerable<Models.Products> GetAllProducts(string productName)
        {
            using (var context = Context)
            {
                if (productName == null)
                {
                    return context.Products.ToList();
                }
                return context.Products.Where(x => x.ProductName.Contains(productName)).ToList();                
            }
        }

        public Models.Products GetProductById(int id)
        {
            using(var context = Context)
            {
                return context.Products.FirstOrDefault(x => x.ProductId == id);
            }
        }

        public void CreateProduct(Models.Products model)
        {
            using(var context = Context)
            {
                context.Products.Add(model);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Models.Products model)
        {
            using (var context = Context)
            {
                context.Products.Update(model);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Models.Products model)
        {
            using(var context = Context)
            {
                context.Products.Remove(model);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
