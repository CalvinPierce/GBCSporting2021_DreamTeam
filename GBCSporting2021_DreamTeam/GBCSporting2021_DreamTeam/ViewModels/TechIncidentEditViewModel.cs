using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.Models
{
    public class TechIncidentEditViewModel : TechIncidentViewModel
    {
        public List<Customer> Customer { get; set; }
        public List<Products> Product { get; set; }
        public List<Technician> TechniciansList { get; set; }
        public Incident Incident { get; set; }
        public int Id { get; set; }
    }
}
