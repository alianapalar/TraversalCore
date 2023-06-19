﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCore.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/Comment/[action]/{id?}")]
	
	public class CommentController : Controller
	{
		private ICommentService _commentService;
		private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var value = _commentService.GetListCommentWithUserAndDestination(user.Id);
			return View(value);
		}
		public IActionResult DeleteComment(int id) 
		{
			var value = _commentService.GetById(id);
			_commentService.TDelete(value);
			return RedirectToAction("Index", "Comment", new { area = "Member" });
		}
	}
}
