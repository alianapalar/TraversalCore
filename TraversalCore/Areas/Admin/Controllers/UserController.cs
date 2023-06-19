using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.GetList();
            return View(values);
        }
        public IActionResult DeleteUser(int id) 
        {
            var user= _appUserService.GetById(id);
            _appUserService.TDelete(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditUser(int id) 
        {
            var user=_appUserService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser user)
        {
            _appUserService.TUpdate(user);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser() 
        {
            return View();
        }
        public IActionResult ReservationUser(int id) 
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);  
        }
    }
}
