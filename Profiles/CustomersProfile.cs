using AutoMapper;
using CBBStoreAPI.Models;
using CBBStoreAPI.VM.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            // Source -> Destination
            CreateMap<Customers, CustomersVM>();
            CreateMap<CustomersVM, Customers>();
        }        
    }
}
