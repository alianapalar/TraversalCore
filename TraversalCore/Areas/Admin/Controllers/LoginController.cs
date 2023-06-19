using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCore.Models;
using static TraversalCore.Areas.Admin.Models.BookingHotelSearchViewModel;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Login/[action]/{id?}")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,false,true);
                if (result.Succeeded)
                {
                    var user = await _signInManager.UserManager.FindByNameAsync(model.Username);

                    if (await _signInManager.UserManager.IsInRoleAsync(user, "Admin"))
                    {
                        // Rolü "admin" olan kullanıcı giriş yaptı, istediğiniz işlemleri yapabilirsiniz.
                        // Örneğin, yönlendirme yapabilirsiniz:
                        return RedirectToAction("Index", "Dashboard", new {area="Admin"});
                    }
                    else
                    {
                        // Rolü "admin" olmayan kullanıcı giriş yaptı, hata mesajı gösterebilirsiniz.
                        ModelState.AddModelError(string.Empty, "Admin yetkiniz yok.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
                    return View(model);
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login", new {area="Admin"});
        }
    }
}
