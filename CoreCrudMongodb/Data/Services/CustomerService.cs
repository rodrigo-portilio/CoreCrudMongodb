using CoreCrudMongodb.Data.Interfaces.Repositories;
using CoreCrudMongodb.Data.Interfaces.Services;
using CoreCrudMongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Delete(string id)
        {
            customerRepository.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        public Customer GetById(string id)
        {
            return customerRepository.GetById(id);
        }

        public void Update(Customer customer)
        {
            customerRepository.Update(customer);
        }
    }
}
