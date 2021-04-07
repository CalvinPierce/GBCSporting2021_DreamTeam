using GBCSporting2021_DreamTeam.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class ValidationController : Controller
    {
       private IncidentContext context { get; set; }

        public ValidationController(IncidentContext ctx) => context = ctx;

        public JsonResult CheckEmail(string email)
        {
            string msg = Check.EmailExists(context, email);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else
                return Json(msg);
        }
    }
}
