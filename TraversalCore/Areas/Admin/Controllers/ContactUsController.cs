using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values=_contactUsService.ActiveContactList();
            return View(values);
        }
       
        public IActionResult ChangeContactUsStat(int id) 
        {
            _contactUsService.ChangeContactUsStat(id);
            return RedirectToAction("Index", "ContactUs", new { area = "Admin" });
        }
    }
}
