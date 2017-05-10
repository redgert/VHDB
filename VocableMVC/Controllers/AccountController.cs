using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using VocableMVC.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VocableMVC.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //var result = _userManager.CreateAsync(new IdentityUser("admin"), "admin123");

            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var result = _userManager.CreateAsync(new IdentityUser("Admin"), "Admin123");

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
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password",result.Errors.First().Description);
                return View(model);
            }
            //Logga in och skicka vidare användaren
            //Logga in användaren (med en icke-persistent cookie)
            await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            //Skicka användaren till en inloggnings-skyddad action
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


    }
}
