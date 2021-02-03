using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBBStoreAPI.Data.Customers
{
    public interface ICustomersRepository
    {
        IEnumerable<Models.Customers> GetAllCustomers();
        Models.Customers GetCustomerById(int id);
        void CreateCustomer(Models.Customers model);
        public void UpdateCustomer(Models.Customers model);
        public void DeleteCustomer(Models.Customers model);
    }
}
       
