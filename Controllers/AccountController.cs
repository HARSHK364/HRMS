using Microsoft.AspNetCore.Mvc;

namespace FM.HRMS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
