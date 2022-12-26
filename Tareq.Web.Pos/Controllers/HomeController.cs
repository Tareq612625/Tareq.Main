using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tareq.Model;
using Tareq.Utility.Web;
using Tareq.Web.Pos.Models;

namespace Tareq.Web.Pos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var itemMaster = new Tareq.Model.Pos.ItemMaster();
            var ip = TareqUtility.GetRemoteIPAddress();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}