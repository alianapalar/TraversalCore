﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCore.Models;


namespace TraversalCore.Controllers
{
    [AllowAnonymous]
    [Route("Login/[action]/{id?}")]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> SignUp(UserRegistrationViewModel userRegister)
        {
            AppUser appuser = new AppUser()
            {
                Name = userRegister.Name,
                Surname= userRegister.Surname,
                Email=userRegister.Mail,
                UserName=userRegister.Username
            };
            if (userRegister.Password == userRegister.ConfirmPassword) 
            {
                var result=await _userManager.CreateAsync(appuser,userRegister.Password);
                if (result.Succeeded) 
                {
                    return RedirectToAction("SignIn");
                }
                else 
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
           return View(userRegister);
        }
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel userLogin) 
        {
            if(ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, false, true);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Profile", new {area="Member"});
                }
                else 
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Default");
        }

	}
}
