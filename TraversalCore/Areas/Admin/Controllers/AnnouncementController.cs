using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.GetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid) 
            {
                _announcementService.TAdd(new Announcement()
                {
                    Content=model.Content,
                    Title=model.Title,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id) 
        {
            var value = _announcementService.GetById(id);
            _announcementService.TDelete(value);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id) 
        {
            var value = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.GetById(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid) 
            {
                _announcementService.TUpdate(new Announcement()
                {
                    AnnouncementID=model.AnnouncementID,
                    Title=model.Title,
                    Content=model.Content,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(model);
        }
    }
}
