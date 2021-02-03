using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Categories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Models.Categories> GetAllCategories();
        Models.Categories GetCategoryById(int id);
        void CreateCategory(Models.Categories model);
        void UpdateCategory(Models.Categories model);
        void DeleteCategory(Models.Categories model);
    }
}
