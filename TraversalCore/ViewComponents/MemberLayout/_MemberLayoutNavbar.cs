﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View(); 
        }
    }
}
