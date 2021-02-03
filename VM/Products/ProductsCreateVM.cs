using CBBStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.VM.Products
{
    public class ProductsCreateVM
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public short ModelYear { get; set; }
        [Required]
        public decimal ListPrice { get; set; }

        public virtual Models.Brands Brand { get; set; }
        public virtual Models.Categories Category { get; set; }
    }
}
