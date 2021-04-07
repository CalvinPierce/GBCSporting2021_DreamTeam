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
        private ISession session { get; set; }

        public ProgramSession(ISession session)
        {
            this.session = session;
        }
        public Technician GetTechnician() => session.GetObject<Technician>(techKey) ?? new Technician();
        public void SetTechnician(Technician technician) { session.SetObject(techKey, technician); }
        public Customer GetCustomer() => session.GetObject<Customer>(custKey) ?? new Customer();
        public void SetCustomer(Customer customer) => session.SetObject(techKey, customer);
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
