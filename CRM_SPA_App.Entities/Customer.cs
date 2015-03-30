using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CRM_SPA_App.Entities
{

    public class Customer
    {


        public string Id { get; set; }

        public double Person_Id { get; set; }

        public string First_Name { get; set; }
        
        public string Last_Name { get; set; }
        
        public string Email { get; set; }
        
        public string Country { get; set; }
        
        public string Language { get; set; }

        public Customer(string firstname,string lastname,string email,string country,string language)
        {
            First_Name = firstname;
            Last_Name = lastname;
            Email = email;
            Country = country;
            Language = language;
        }

        public Customer()
        {

        }
    }
}
