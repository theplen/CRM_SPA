using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CRM_SPA_App.Entities;
using Newtonsoft.Json;

namespace CRM_SPA_App.Repositories.File
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll(){
            var customerString = System.IO.File.ReadAllText("c:\\testdata\\customers.json");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customerString);
            return customers;
        }

        public List<Customer> GetByID(string id)
        {
            var customerString = System.IO.File.ReadAllText("c:\\testdata\\customers.json");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(customerString);
            return customers;
        }
    }
}
