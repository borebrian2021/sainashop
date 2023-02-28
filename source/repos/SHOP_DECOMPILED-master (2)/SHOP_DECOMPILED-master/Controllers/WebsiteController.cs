using Lubes.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace SHOP_DECOMPILED.Controllers
{
    public class WebsiteController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WebsiteController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult Products()
        {
            ViewBag.fuel = _context.Fuel_category;
            return View();
        }  
        public IActionResult Testimonials()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            return View();
        }
        public IActionResult Quotation()
        {
            return View();
        } 
        public IActionResult Category()
        {
            return View();
        } 

        public IActionResult send_quotation(string name, string phone, string email ,string message_, string service )
        {
          
               try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("supremesai2021@gmail.com");
                    message.To.Add(new MailAddress("supremesai2021@gmail.com"));
                    message.Subject = "You have new quotation request from from a client.";
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body = "<html><body>" +
                    "<img src=\"https://res.cloudinary.com/dqab6gg7d/image/upload/v1674139232/Supremesai/saina_logo_uvc4cj.png\" style=\"height:70px;width:7-px\" <br/>" +
                    "<table style=\"margin:15px;\">" +
                    "<tr>" +
                    "<td style=\"margin:10px;\"><b style=\"color:#a7b3c8\">Supreme <span style=\"color:#1c98f7\">Sai Enterprises</span></td> <td></td>" +
                    "</tr>" + "<tr>" +
                    "<td style=\"margin:10px;\">New mail from: </td> <td>" + name + "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td style=\"margin:10px;\">Email: </td> <td>" + email + "</td>" +
                    "</tr>" +
                    "</tr>" +
                    "<tr>" +
                    "<td style=\"margin:10px;\">Phone number: </td> <td>" + phone + "</td>" +
                    "</tr>" +
                     "<tr>" +
                    "<td style=\"margin:10px;\">Time: </td> <td>" + DateTime.Now + "</td>" +
                    "</tr>" +  
                    "<tr>" +
                    "<td style=\"margin:10px;\">Service Required: </td> <td>" + service+ "</td>" +
                    "</tr>" +
                      "<tr>" +
                    "<td style=\"margin:10px;\">Message: </td> <td>" + message_ + "</td>" +
                    "</tr>" +
                    "</table>";
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("supremesai2021@gmail.com", "pmuarpvsojnqlama");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    @TempData["message"] = "Thank you for contacting Supreme Sai Enterprise.\n Your message has been sent successfully, Please wait for reply from customer service.";
                    smtp.Send(message);

                }
                catch (Exception) { }
            return Redirect("~/Website/Quotation");


        }
    }
}
