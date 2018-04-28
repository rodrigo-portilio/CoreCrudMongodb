using CoreCrudMongodb.Data.Interfaces.Repositories;
using CoreCrudMongodb.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContext dbContext;

        public CustomerRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(string id)
        {
            dbContext.Customers.DeleteOne(Builders<Customer>.Filter.Eq(x => x.Id, id));
        }

        public IEnumerable<Customer> GetAll()
        {
            return dbContext.Customers.Find(x => true).ToList();
        }

        public Customer GetById(string id)
        {
            return dbContext.Customers.Find(x => x.Id == id).FirstOrDefault();
        }

        public void Update(Customer customer)
        {
            if (customer.Id != null)
            {
                var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
                var update = Builders<Customer>.Update
                    .Set(x => x.City, customer.City)
                    .Set(x => x.Country, customer.Country)
                    .Set(x => x.Email, customer.Email)
                    .Set(x => x.FirstName, customer.FirstName)
                    .Set(x => x.LastName, customer.LastName)
                    .Set(x => x.State, customer.State)
                    .Set(x => x.Street, customer.Street);                    
                dbContext.Customers.UpdateOne(filter, update);
            }
            else
            {
                dbContext.Customers.InsertOne(customer);
            }
        }
    }
}
