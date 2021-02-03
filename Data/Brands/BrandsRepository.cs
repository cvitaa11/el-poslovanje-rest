using CBBStoreAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Brands
{
    public class BrandsRepository : IBrandsRepository
    {
        #region fields
        private CBBStoreContext Context => new CBBStoreContext(_config);
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public BrandsRepository(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region implementation
        public IEnumerable<Models.Brands> GetAllBrands()
        {
           using(var context = Context)
            {
                return context.Brands.ToList();
            }
        }

        public Models.Brands GetBrandById(int id)
        {
            using(var context = Context)
            {
                return context.Brands.Where(x => x.BrandId == id).FirstOrDefault();
            }
        }

        public void CreateBrand(Models.Brands model)
        {
            using(var context = Context)
            {
                context.Brands.Add(model);
                context.SaveChanges();
            }
        }

        public void UpdateBrand(Models.Brands model)
        {
            using (var context = Context)
            {
                context.Brands.Update(model);
                context.SaveChanges();
            }
        }

        public void DeleteBrand(Models.Brands model)
        {
            using(var context = Context)
            {
                context.Brands.Remove(model);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
