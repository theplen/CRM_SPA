using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using CRM_SPA_App.Entities;
using MongoDB.Driver.Builders;

namespace CRM_SPA_App.Repositories.MongoDB
{    
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MongoCollection<Customer> _customers;

        public CustomerRepository()
        {
            var mongoDB = new MongoDB();
            _customers = mongoDB.DB.GetCollection<Customer>("customers");
        }

        public List<Customer> GetAll()
        {            
            var customers = _customers.FindAll().ToList<Customer>();
            return customers;
        }

        public Customer Get(string id)
        {
            var customer = _customers.FindOne(Query.EQ("person_id", Double.Parse(id)));
            return customer;
        }
    }
}
