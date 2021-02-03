using CBBStoreAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Categories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        #region fields
        private CBBStoreContext Context => new CBBStoreContext(_config);
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public CategoriesRepository(IConfiguration config)
        {
            _config = config;
        }
        #endregion

        #region implementation
        public IEnumerable<Models.Categories> GetAllCategories()
        {
            using(var context = Context)
            {
                return context.Categories.ToList();
            }
        }

        public Models.Categories GetCategoryById(int id)
        {
            using (var context = Context)
            {
                return context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            }
        }

        public void CreateCategory(Models.Categories model)
        {
            using (var context = Context)
            {
                context.Categories.Add(model);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Models.Categories model)
        {
            using (var context = Context)
            {
                context.Categories.Update(model);
                context.SaveChanges();
            }
        }

        public void DeleteCategory(Models.Categories model)
        {
            using (var context = Context)
            {
                context.Categories.Remove(model);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
