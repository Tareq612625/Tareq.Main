using Microsoft.AspNetCore.Mvc;

namespace Tareq.Web.Pos.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
