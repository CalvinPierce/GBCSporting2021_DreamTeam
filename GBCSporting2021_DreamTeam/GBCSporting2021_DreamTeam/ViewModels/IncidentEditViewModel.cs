using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.Models
{
    public class IncidentEditViewModel : IncidentViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Products> Products { get; set; }
        public List<Technician> Technicians { get; set; }
        public Incident Incident { get; set; }

        public string Action { get; set; }
    }
}
