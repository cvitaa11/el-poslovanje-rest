using AutoMapper;
using CBBStoreAPI.Models;
using CBBStoreAPI.VM.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<CategoriesVM, Categories>();
            CreateMap<Categories, CategoriesVM>();
        }
    }
}
