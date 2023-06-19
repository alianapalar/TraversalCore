using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            //ViewBag.destID = id;
            //ViewBag.userID
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment c) 
        {
            c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.CommentState = true;
            
            _commentService.TAdd(c);
            return RedirectToAction("Index", "Destination");
        }

    }
}
