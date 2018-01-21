using CoreCrudMongodb.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrudMongodb.Data
{
    public class DbContext
    {
        private IMongoDatabase db;

        public DbContext()
        {
            db = new MongoClient("mongodb://localhost:27017").GetDatabase("CoreCrudMongodb");
        }

        public void Seed()
        {
            var customers = this.Customers.Find(x => true).ToList();
            if( customers.Count() == 0)
            {
                var newCustomers = new List<Customer>();

                newCustomers.Add(new Customer() {
                    State = "New York",
                    City = "New York City",
                    Country = "United States",
                    Email = "james@outlook.com",
                    FirstName = "James",
                    LastName = "Roth",
                    Street = "W Broadway"
                });

                newCustomers.Add(new Customer()
                {
                    State = "Texas",
                    City = "El Passo",
                    Country = "United States",                
                    Email = "john@outlook.com",
                    FirstName = "John",
                    LastName = "Lee",
                    Street = "Memphis Ave"
                });

                newCustomers.Add(new Customer()
                {
                    State = "California",
                    City = "Los Angeles",
                    Country = "United States",
                    Email = "edgar@outlook.com",
                    FirstName = "Edgar",
                    LastName = "Talese",
                    Street = "S Spring"
                });
                this.Customers.InsertMany(newCustomers);

            }
        }

        public IMongoCollection<Customer> Customers        {
            get
            {
                return db.GetCollection<Customer>("customers");
            }
        }
    }
}
