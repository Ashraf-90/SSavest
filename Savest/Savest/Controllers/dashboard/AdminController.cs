using Microsoft.AspNetCore.Mvc;

namespace Savest.Controllers.dashboard
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("AdminID", "XXXXXXXXXXXXXXXXXXXXXX");
            return View();
        }
    }
}
