using CBBStoreAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Customers
{
    public class CustomersRepository : ICustomersRepository
    {
        #region fields
        private CBBStoreContext Context => new CBBStoreContext(_config);
        private readonly IConfiguration _config;
        #endregion

        #region ctor
        public CustomersRepository(IConfiguration config)
        {
            _config = config;
        }
        #endregion
        public IEnumerable<Models.Customers> GetAllCustomers()
        {
            using (var context = Context)
            {
                return context.Customers.ToList();
            }
        }

        public Models.Customers GetCustomerById (int id)
        {
            using(var context = Context)
            {
                return context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            }
        }

        public void CreateCustomer(Models.Customers model)
        {           
            using (var context = Context)
            {
                context.Customers.Add(model);
                context.SaveChanges();
            }
        }

        public void UpdateCustomer(Models.Customers model)
        {
            using (var context = Context)
            {
                context.Customers.Update(model);
                context.SaveChanges();
            }
        }

        public void DeleteCustomer(Models.Customers model)
        {
            using (var context = Context)
            {
                context.Customers.Remove(model);
                context.SaveChanges();
            }
        }
    }
}
