using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values=_guideService.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules= new GuideValidator();
            ValidationResult result= validationRules.Validate(guide);
            if (result.IsValid) 
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else 
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult EditGuide(int id) 
        {
            var value=_guideService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide) 
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeGuideStat(int id) 
        {
            _guideService.ChangeGuideStat(id);
            return RedirectToAction("Index", "Guide", new {area="Admin"});
        }
        public IActionResult DeleteGuide(int id) 
        {
            var value=_guideService.GetById(id);
            _guideService.TDelete(value);
            return RedirectToAction("Index", "Guide", new {area="Admin"});
        }
    }
}
