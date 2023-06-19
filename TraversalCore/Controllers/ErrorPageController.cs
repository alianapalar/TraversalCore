using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
