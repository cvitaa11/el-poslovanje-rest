using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Brands
{
    public interface IBrandsRepository
    {
        IEnumerable<Models.Brands> GetAllBrands();
        void CreateBrand(Models.Brands model);
        void UpdateBrand(Models.Brands model);
        Models.Brands GetBrandById(int id);
        void DeleteBrand(Models.Brands model);
    }
}
