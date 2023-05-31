using Bintex.Data.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Bintex.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintex.WebApp.ViewModels.Account;

namespace Bintex.WebApp.Components
{
    public class PanelUserInfoViewComponent:ViewComponent
    {
        UserManager<BintexUser> _userManager;
        public PanelUserInfoViewComponent(UserManager<BintexUser> userManager)
        {
            _userManager=userManager;   
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var info = new PanelUserInfoViewModel();
            var userInfo = await _userManager.GetUserAsync(HttpContext.User);   

            info.ProfileImage = userInfo.ProfileImage;
            info.Name = userInfo.Name;
            info.Id=userInfo.Id;

          
                
           return View(info);  
        }

    }
}
