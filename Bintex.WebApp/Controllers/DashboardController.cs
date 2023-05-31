using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintex.WebApp.Controllers
{
    public class DashboardController : PanelController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
