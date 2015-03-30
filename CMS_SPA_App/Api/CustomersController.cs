using CRM_SPA_App.Entities;
using CRM_SPA_App.Repositories;
using CRM_SPA_App.Repositories.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRM_SPA_App.Api
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController() : this(new CustomerRepository())
        {

        }

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
       
        // GET: api/Customers
        public List<Entities.Customer> Get()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        // GET: api/Customers/5
        public Customer Get(string id)
        {
            var customer = _customerRepository.Get(id);
            return customer;
        }

        // POST: api/Customers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
