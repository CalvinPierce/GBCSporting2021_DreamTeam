using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_DreamTeam.Models
{
    public class ProgramSession
    {
        private const string techKey = "technician";
        private const string custKey = "customer";
        private ISession session;

        public ProgramSession(ISession sess) => session = sess;
        public List<Technician> GetTechnician() => session.GetObject<List<Technician>>(techKey) ?? new List<Technician>();
        public void SetTechnician(List<Technician> technician) => session.SetObject(techKey, technician);
        public Customer GetCustomer() => session.GetObject<Customer>(custKey) ?? new Customer();
        public void SetCustomer(Technician technician) => session.SetObject(techKey, technician);
        public void RemoveTechnician()
        {
            session.Remove(techKey);
        }
        public void RemoveCustomer()
        {
            session.Remove(custKey);
        }
    }
}
