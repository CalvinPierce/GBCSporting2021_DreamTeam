using GBCSporting2021_DreamTeam.DataAccess;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Check
    {
        public static string EmailExists(IncidentContext context, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = context.Customers.FirstOrDefault(
                    c => c.Email.ToLower() == email.ToLower());
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
    }
}
