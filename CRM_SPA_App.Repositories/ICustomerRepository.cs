using CRM_SPA_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_SPA_App.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer Get(string id);
    }
}
