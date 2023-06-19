using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        Context context= new Context();
        public IViewComponentResult Invoke(int id) 
        {
            ViewBag.commentCount=context.Comments.Where(x=>x.DestinationID==id).Count();
            var values=_commentService.GetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
