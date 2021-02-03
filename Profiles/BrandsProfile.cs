using AutoMapper;
using CBBStoreAPI.VM.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Profiles
{
    public class BrandsProfile : Profile
    {
        public BrandsProfile()
        {
            CreateMap<Models.Brands, BrandsVM>();
            CreateMap<BrandsVM, Models.Brands>();
        }
    }
}
