using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using VocableMVC.Models.ViewModels;
using VocableMVC.Models.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocableMVC.Controllers
{
    public class AccountController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;
        private VHDBContext _vhdbcontext;

        public AccountController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext dbContext,
            VHDBContext vhdbcontext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = dbContext;
            _vhdbcontext = vhdbcontext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //var result = _userManager.CreateAsync(new IdentityUser("admin"), "admin123");
            
            //var result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            //var result2 = await _roleManager.CreateAsync(new IdentityRole("Teacher"));
            //var result3 = await _roleManager.CreateAsync(new IdentityRole("Student"));

            ////var result4 = await _userManager.CreateAsync(new IdentityUser("Administ"), "Admin"); 
            //var user = await _userManager.FindByNameAsync("Mats");
            //var result5 = await _userManager.AddToRoleAsync(user, "Admin");
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            //var result = _userManager.CreateAsync(new IdentityUser("Admin"), "Admin123");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginVM model)
        {
            //Validera vy-modellen
            if (!ModelState.IsValid)
                return View(model);

            //Logga in användaren (med en icke-persistent cookie)
            await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            //Skicka användaren till en inloggnings-skyddad action
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            //var result = _userManager.CreateAsync(new IdentityUser("Admin"), "Admin123");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterVM model)
        {
            //Validera vy-modellen
            if (!ModelState.IsValid)
                return View(model);

            //Skapa användare
            await _identityContext.Database.EnsureCreatedAsync();

            //Spara användaren i databasen
            var result = await _userManager.CreateAsync(new IdentityUser(model.UserName),
                model.Password);
            //när identity är klar
            //tar resterande data från anv. i VM. 
            //Skickar det till vår VHDBcontext
            var userId = await _userManager.FindByNameAsync(model.UserName);
            _vhdbcontext.AddUserDetails(model.FirstName, model.LastName, userId.Id);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password",result.Errors.First().Description);
                return View(model);
            }

            //var result = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            //var result2 = await _roleManager.CreateAsync(new IdentityRole("Teacher"));
            //var result3 = await _roleManager.CreateAsync(new IdentityRole("Student"));

            ////var result4 = await _userManager.CreateAsync(new IdentityUser("Administrator"), "Admin"); 
            //var user = await _userManager.FindByNameAsync("Mats");
            //var result5 = await _userManager.AddToRoleAsync(user, "Admin");


            //Logga in och skicka vidare användaren
            //Logga in användaren (med en icke-persistent cookie)
            await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            //Skicka användaren till en inloggnings-skyddad action
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


    }
}
