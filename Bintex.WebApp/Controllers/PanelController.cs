using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bintex.WebApp.Controllers
{
    [Authorize(Roles ="Admin") ]
    public class PanelController : Controller
    {
      
    }
}
