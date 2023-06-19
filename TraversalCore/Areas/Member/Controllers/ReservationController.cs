using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Reservation/[action]/{id?}")]
    public class ReservationController : Controller
    {
        IDestinationService _destinationService;
        IReservationService _reservationService;

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager, IDestinationService destinationService, IReservationService reservationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> MyCurrentReservation() 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationService.GetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyOldReservation()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationService.GetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyApprovalReservation() 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationService.GetListWithReservationByWaitApproval(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> value=(from x in _destinationService.GetList() 
                                        select new SelectListItem 
                                        {
                                            Text=x.City,
                                            Value=x.DestinationID.ToString()
                                        }).ToList();
            TempData["Destinations"] = value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(ReservationAddDTO reservation) 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
           
            if (ModelState.IsValid) 
            {
                _reservationService.TAdd(new Reservation()
                {
                    AppUserId = values.Id,
                    PersonCount = reservation.PersonCount.ToString(),
                    ReservationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Description = reservation.Description,
                    Status = "Onay Bekliyor",
                    DestinationID= reservation.DestinationID,
                    
                    
                   
                });
                return RedirectToAction("MyApprovalReservation", "Reservation", new { area = "Member" });
            }
           
            return View(reservation);
        }
    }
}
