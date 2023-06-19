using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCore.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("Admin/Mail/[action]/{id?}")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest) 
        {
            MimeMessage mimeMessage=new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "kemalyerli345@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody= mailRequest.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();
            mimeMessage.Subject= mailRequest.Subject;

            SmtpClient smtpClient= new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("kemalyerli345@gmail.com", "ywxryjvydybdikii");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
