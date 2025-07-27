﻿using FoodMartMongo.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace FoodMartMongo.Controllers
{
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
            if (string.IsNullOrWhiteSpace(mailRequest.ReceiverMail))
            {
                ModelState.AddModelError("ReceiverMail", "E-posta adresi boş olamaz.");
                return RedirectToAction("Index", "Default");
            }
            MimeMessage mimeMessage = new MimeMessage();

            var mailboxAddressFrom = new MailboxAddress("Admin", "foodmartmongo@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            var mailboxAddressTo = new MailboxAddress(mailRequest.Name ?? "", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = "Tebrikler! %25 İndirim Kodu Kazandınız";


            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
        <div style='font-family: Verdana, Geneva, Tahoma, sans-serif; line-height: 1.5; color: #333;'>
        	<h1 style='color: #28a745;'>Tebrikler, {mailRequest.Name}!</h1>
        	<p>Size özel <strong>%25 indirim kuponu</strong> kazandınız!</p>
        	<p>Bu fırsatı ilk siparişinizde kullanarak büyük avantaj sağlayabilirsiniz:</p>
        	<div style='padding: 12px; background-color: #e9ecef; border-radius: 5px; display: inline-block;'>
        		<strong style='font-size: 22px; letter-spacing: 2px;'>INDIRIM25</strong>
        	</div>
        	<p>Hemen alışverişe başlamak için web sitemizi ziyaret edin</a>.</p>
        	<p>Keyifli alışverişler dileriz!<br><strong>FoodMart Ekibi</strong></p>
        </div>"

            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using var smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("foodmartmongo@gmail.com", "bvpnggmyejzipivt");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            TempData["Success"] = "Mail başarıyla gönderildi.";
            return RedirectToAction("Index", "Default");
        }
    }
}

//bvpn ggmy ejzi pivt