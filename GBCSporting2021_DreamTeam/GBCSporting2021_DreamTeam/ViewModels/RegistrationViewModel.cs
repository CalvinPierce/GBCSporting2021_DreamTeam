using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.Models
{
    public class RegistrationViewModel
    {
        public List<Products> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Registration> Registrations { get; set; }
        public Customer Customer { get; set; }
        public Registration Registration { get; set; }
        public int customerId { get; set; }
        public int productId { get; set; }
    }
}
