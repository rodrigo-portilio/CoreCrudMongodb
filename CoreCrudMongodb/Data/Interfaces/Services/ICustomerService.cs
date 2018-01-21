using CoreCrudMongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(string id);
        void Update(Customer customer);
        void Delete(string id);
    }
}
