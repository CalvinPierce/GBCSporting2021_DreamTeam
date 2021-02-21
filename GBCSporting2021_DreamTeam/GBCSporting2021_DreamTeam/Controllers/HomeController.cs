using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_DreamTeam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
