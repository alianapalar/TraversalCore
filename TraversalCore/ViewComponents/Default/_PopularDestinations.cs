using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.Default
{
    public class _PopularDestinations:ViewComponent
    {
        IDestinationService _destinationService;

        public _PopularDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke() 
        {
            var values = _destinationService.GetList();
            return View(values);
        }
    }
}
