using AutoMapper;
using Bintex.Data;
using Bintex.Data.Entities.Account;
using Bintex.WebApp.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bintex.WebApp.Controllers
{
    public class AccountController : Controller
    {
        #region Login

        SignInManager<BintexUser> _signInManager;
        UserManager<BintexUser> _userManager;
        IUserStore<BintexUser> _userStore;
        IRoleStore<BintexRole> _roleStore;
        BintexContext _database;
        IMapper _mapper;
        public AccountController(SignInManager<BintexUser> signInManager,
            UserManager<BintexUser> userManager, IUserStore<BintexUser> userStore, IRoleStore<BintexRole> roleStore,
            BintexContext database, IMapper mapper
            )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _roleStore = roleStore;
            _database = database;
            _mapper = mapper;
        }
        public async Task<IActionResult> Login()
        {
            //program hata verdiği için kaldırılmadı, admin ve student rolleri elle eklendi
             var role = new BintexRole();
             await _roleStore.SetRoleNameAsync(role, "Admin", new CancellationToken());
             await _roleStore.CreateAsync(role, new CancellationToken());

            var role1 = new BintexRole();
            await _roleStore.SetRoleNameAsync(role1, "Student", new CancellationToken());
            await _roleStore.CreateAsync(role1, new CancellationToken());

            await _signInManager.SignOutAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            BintexUser findedUser = await _userManager.FindByEmailAsync(model.EmailAdress);
            if (findedUser == null)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(findedUser, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return Redirect("/Home/Index");
            }
            return View(model);
        }

        #endregion

        #region Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //async metodlar mutlaka task tipinde geri dönüş vermeli, async metodlar await dönüşler vermeli.

           var findedUser = await _userManager.FindByEmailAsync(model.Email);
            if(findedUser != null)
            return View(model);

            var userInfo = new BintexUser();
            userInfo.Name = model.Name;
            userInfo.Surname = model.Surname;
            userInfo.IdentityNumber = "";
            userInfo.ProfileImage = "";
            userInfo.BirthDate = DateTime.Now;
            await _userManager.SetEmailAsync(userInfo, model.Email);
            

            var result = await _userStore.CreateAsync(userInfo, new CancellationToken());
            if (result.Succeeded)
            {
                await _userManager.SetUserNameAsync(userInfo, model.Email);
                await _userManager.AddPasswordAsync(userInfo, model.Password);
                await _userManager.AddToRoleAsync(userInfo, "Student");
                await _signInManager.PasswordSignInAsync(userInfo, model.Password, false, false);
                return Redirect("/Home/Index");
                    
            }
            return View(model);

        }

        #endregion

        #region
        public async Task<IActionResult> Roles()
        {
           var dataList = _database.Roles.ToList().Select(item => _mapper.Map<RoleListViewModel>(item)).ToList();
            return View(dataList);
        }

        public async Task<IActionResult> AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddViewModel vm)
        {
            var isExist = _database.Roles.Any(p => p.Name == vm.Name);

            if (isExist) 
            {
                ModelState.AddModelError("Name", "Bu rol zaten mevcut");
                return View(vm);
            }


            var br = _mapper.Map<BintexRole>(vm);
            br.NormalizedName = vm.Name.ToUpperInvariant();
            _database.Roles.Add(br);
            _database.SaveChanges();
            return RedirectToAction("Roles");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var findedUser =_database.Roles.FirstOrDefault(p=> p.Id == Convert.ToInt32(id));
            if (findedUser == null)
                return Json(new { status = false });

            _database.Roles.Remove(findedUser);
            _database.SaveChanges();
            return Json(new { status = true });
        }


        public async Task<IActionResult> UpdateRole(int id)
        {
            var findedUser = _database.Roles.FirstOrDefault(p => p.Id ==id);
            if (findedUser == null)
                return RedirectToAction("Roles");

            var model = _mapper.Map<RoleUpdateViewModel>(findedUser);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel vm)
        {
            var findedRole = _database.Roles.FirstOrDefault(p=>p.Id == vm.Id);
            findedRole.NormalizedName = vm.Name.ToUpperInvariant();
            findedRole.Name = vm.Name;
            _database.SaveChanges();
            return RedirectToAction("Roles");
        }

        #endregion
    }
}
