﻿using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCore.Areas.Admin.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Account/[action]/{id?}")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderID);
            var valueReceiver=_accountService.TGetById(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance+=model.Amount;
            List<Account> modifiedAccounts= new List<Account>() 
            {
                valueSender, valueReceiver
            };
            _accountService.MultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
