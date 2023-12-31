﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.GetList();
            return View(values);
        }
        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in  _destinationService.GetList() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.ToLower().Contains(searchString.ToLower()));
            }
            return View(values.ToList());
        }
    }
}
