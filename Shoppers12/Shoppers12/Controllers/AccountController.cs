using Shoppers12.Data;
using Shoppers12.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shoppers12.Controllers
{
    public class AccountController : Controller
    {
        Shoppers12DbContext _context;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(Shoppers12DbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        #region registreer
        [HttpGet]
        public IActionResult Registreer()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistreerAsync(RegistreerViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (registerViewModel.RoleId != null)
                {
                    var identityUser = new IdentityUser();
                    identityUser.Email = registerViewModel.Email;
                    identityUser.UserName = registerViewModel.Email;
                    var identityResult = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                    if (identityResult.Succeeded)
                    {
                        var identityRole = await _roleManager.FindByIdAsync(registerViewModel.RoleId);
                        var roleResult = await _userManager.AddToRoleAsync(identityUser, identityRole.Name);
                        if (roleResult.Succeeded)
                            return View("Login");
                        else
                        {
                            ModelState.AddModelError("", "Problemen met toekennen van rol!");
                            return View();
                        }
                    }
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Geen rol geselecteerd!");
                }
            }
            return View();
        }
        #endregion
        #region login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel login)
        {
            var identityUser = await _userManager.FindByEmailAsync(login.Email);
            if (identityUser != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(identityUser.UserName, login.Password, false, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Probleem met inloggen");
            return View();
        }
        #endregion
        #region logout

        [HttpPost]
        public async Task<IActionResult> Logout()
        { 
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
        #region AccesDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion
    }
}
