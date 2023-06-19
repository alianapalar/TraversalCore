using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ReservationDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Reservation/[action]/{id?}")]
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            
        }

        public IActionResult Index()
		{
			var values = _mapper.Map<List<ReservationListDTO>>
				(_reservationService.GetListWithReservationAppUserAndDestination());
			return View(values);
		}
		
        public IActionResult ChangeReservationStatus(int id)
        {
            _reservationService.ChangeReservationStatus(id);
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });
        }
        public IActionResult ChangePastReservation(int id)
        {
            _reservationService.ChangePastReservation(id);
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });
        }
    }
}
