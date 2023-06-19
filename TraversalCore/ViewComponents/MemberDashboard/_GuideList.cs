using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.MemberDashboard
{
    public class _GuideList:ViewComponent
    {
        IGuideService _guideService;

        public _GuideList(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke() 
        {
            var values = _guideService.GetList();
            return View(values);
        }
    }
}
