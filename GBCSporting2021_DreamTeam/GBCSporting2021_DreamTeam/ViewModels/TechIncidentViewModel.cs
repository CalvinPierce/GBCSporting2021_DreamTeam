using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.Models
{
    public class TechIncidentViewModel
    {
        public List<Incident> Incident { get; set; }
        public List<Technician> TechniciansList { get; set; }
        public Technician Technician { get; set; }
        public int Id { get; set; }
    }
}
