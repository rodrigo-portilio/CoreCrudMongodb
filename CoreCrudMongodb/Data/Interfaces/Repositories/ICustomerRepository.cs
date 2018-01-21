using CoreCrudMongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(string id);
        void Update(Customer customer);
        void Delete(string id);
    }
}
