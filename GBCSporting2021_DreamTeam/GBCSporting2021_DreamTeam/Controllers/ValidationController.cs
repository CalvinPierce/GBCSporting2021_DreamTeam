using GBCSporting2021_DreamTeam.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class ValidationController : Controller
    {
        private UnitOfWork unitOfWork;

        public ValidationController(IncidentContext ctx)
        {
            unitOfWork = new UnitOfWork(ctx);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckEmail(string email, int id)
        {
            bool result;
            var customerCheck = unitOfWork.CustomerRepository.Get().Where(c => c.Email == email && c.CustomerId != id && c.Email != null).FirstOrDefault();

            if (customerCheck != null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return Json(result);
        }
    }
}
