using AutoMapper;
using CBBStoreAPI.Models;
using CBBStoreAPI.VM.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Profiles
{
    public class ProductsProfile : Profile
    {
        #region ctor
        public ProductsProfile()
        {
            // Source -> Destination
            CreateMap<Products, ProductsVM>();
            CreateMap<ProductsCreateVM, Products>();
            CreateMap<ProductsUpdateVM, Products>();
        }
        #endregion
    }
}
