using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LokwaInnovation;
using Lubes.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;

namespace DonsSystem.Controllers
{
    public class WebController : Controller
    {
        private readonly ApplicationDBContext _context;
        private static TimeZoneInfo E_Africa_standard_time = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
        private static DateTime today1 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, E_Africa_standard_time);
        string today = today1.ToString("dd/MM/yyyy");
        public WebController(ApplicationDBContext context)
        {

            _context = context;
        }

        //public IActionResult Log_in_user(int Username,String Password)
        //{
        //    string pass = Password;
        //    TokenProvider_admin TokenProviderr = new TokenProvider_admin(_context);
        //    string userToken = TokenProviderr.LoginUser(Username,Password);
        //    if (userToken == null)
        //    {
        //        base.TempData["Error"] = "Invalid login credentials";
        //        return Redirect("~/Web/log_in");
        //    }
        //    HttpContext.Session.SetString("JWToken", userToken);
        //    System_users user_id = _context.System_users.Where(x => x.Phone == Username).SingleOrDefault();
        //    if (user_id.Roles.ToString() == "1")
        //    {
        //        //HttpContext.Session.SetString("roles", user_id.strRole.ToString());
        //        //HttpContext.Session.SetString("Name", user_id.Full_name);
        //        //HttpContext.Session.SetString("shop_name", user_id.Shop_name);
        //        //log_in constants2 = _context.Log_in.FirstOrDefault((log_in x) => x.strRole == 1);
        //        //HttpContext.Session.SetString("phone", constants2.Phone);
        //        //HttpContext.Session.SetString("id", constants2.id.ToString());
        //        return Redirect("~/home/admin");
        //    }
        //    HttpContext.Session.SetString("roles", user_id.strRole.ToString());
        //    HttpContext.Session.SetString("Name", user_id.Full_name);
        //    HttpContext.Session.SetString("shop_name", user_id.Shop_name);
        //    log_in constants = _context.Log_in.FirstOrDefault((log_in x) => x.strRole == 1);
        //    HttpContext.Session.SetString("id", constants.id.ToString());
        //    HttpContext.Session.SetString("phone", user_id.Phone);
        //    return Redirect("~/home/attendant");
        //}
        public IActionResult index()
        {
            ViewBag.fuel_category = _context.Fuel_category.ToList();

            return View();
        }
        public IActionResult errr()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }
        public IActionResult coming_soon()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult faq()
        {
            return View();
        }
        public IActionResult forget_password()
        {
            return View();
        }
        public IActionResult gallery()
        {
            return View();
        }
        public IActionResult load_more()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult pricing()
        {
            ViewBag.fuel_category = _context.Fuel_category.ToList();

            return View();
        }
        public IActionResult register()
        {
            return View();
        }
        public IActionResult services()
        {
            return View();
        }
        public IActionResult services_detail()
        {
            return View();
        }
        public IActionResult single_index()
        {
            return View();
        }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}