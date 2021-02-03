using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.VM.Brands
{
    public class BrandsVM
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Models.Products> Products { get; set; }
    }
}
