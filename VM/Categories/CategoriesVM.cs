using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.VM.Categories
{
    public class CategoriesVM
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Models.Products> Products { get; set; }
    }
}
