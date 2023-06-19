using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCore.CQRS.Commands.GuideCommands;
using TraversalCore.CQRS.Queries.GuideQueries;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/GuideMediaTR/[action]/{id?}")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuides(int id) 
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command) 
        {
            await _mediator.Send(command);
            return RedirectToAction("Index", "GuideMediatR", new { area = "Admin" });
        }
        public async Task<IActionResult> DeleteGuide(int id) 
        {
            var value=await _mediator.Send(new RemoveGuideCommand(id));
            return RedirectToAction("Index", "GuideMediatR", new { area = "Admin" });
        }
        
        [HttpPost]
        public async Task<IActionResult> GetGuides(UpdateGuideCommand update) 
        {
            await _mediator.Send(update);
            return RedirectToAction("Index", "GuideMediatR", new { area = "Admin" });
        }
    }
}
