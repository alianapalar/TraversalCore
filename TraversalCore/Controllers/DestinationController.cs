using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.GetList();
            return View(values);
        }
        //[HttpGet]
        public async Task<IActionResult> DestinationDetails(int id) 
        {
            ViewBag.i= id;
            ViewBag.destId = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id;
            var values=_destinationService.GetDestinationWithGuide(id);
            return View(values);
        }
        //[HttpPost]
        //public IActionResult DestinationDetails(Destination d) 
        //{
        //    return View();
        //}
    }
}
