using Bintex.Data.Entities.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bintex.WebApp.Controllers
{
    public class HomeController : Controller
    {
        UserManager<BintexUser> _userManager;
        public HomeController(UserManager<BintexUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles ="Student,Admin")]
        public async Task<IActionResult> Index()
        {
            var userInfo = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.Username = userInfo;
            return View();
        }
    }
}
