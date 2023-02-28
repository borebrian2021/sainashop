using Aspose.BarCode.Generation;
using Lubes.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QRCoder;
using SAINA.Models;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SAINA.Controllers
{
    public class system_twoController : Controller
    {
        private readonly ILogger<system_twoController> _logger;
        private readonly ApplicationDBContext _context;

        private static TimeZoneInfo E_Africa_standard_time = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
        private static DateTime today1 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, E_Africa_standard_time);
        string today = today1.ToString("dd/MM/yyyy HH: mm:ss");
        public system_twoController(ILogger<system_twoController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;


        }
        [Authorize]
        public IActionResult home_details(int id)
        {
            var c = _context.Clients.Where(c => c.id == id).FirstOrDefault(x => x.id == id);
            var d = _context.Deliveries.Where(c => c.client_id == id).Count();
            var e = _context.Invoices.Where(c => c.client_id == id).Count();
            var f = _context.Receipts.Where(c => c.client_id == id).Count();
            var g = _context.Receipts.Where(c => c.client_id == id).Count();
            ViewBag.i_list = _context.Invoices.Where(c => c.client_id == id).ToList();
            ViewBag.particular_list = _context.Particulars.Where(c => c.client_id == id).ToList();
            ViewBag.receipts_ = _context.Receipts.Where(c => c.client_id == id).ToList();
            ViewBag.s_list = _context.Receipts.Where(c => c.client_id == id).ToList();
            ViewBag.d_list = _context.Deliveries.Where(c => c.client_id == id).ToList();
            ViewBag.client_name = c.Client_name;
            ViewBag.client_balance = c.account_balance;
            ViewBag.c_invoice = c.account_balance;
            ViewBag.receipts = c.account_balance;
            ViewBag.deliveries = d;
            ViewBag.invoices = e;
            ViewBag._receipts = f;
            ViewBag.id = id;
            return View();
        }

        //[Authorize]
        [AllowAnonymous]
        public IActionResult Category(int id)
        {
            return View();

        }
        private static Byte[] Barcode(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private void GenerateBacode(string _data, string _filename)
        {
            BarcodeGenerator generator = new BarcodeGenerator(EncodeTypes.Code128, "Aspose.BarCode");

            // set resolution
            generator.Parameters.Resolution = 400;
            generator.ToString();

            // generate barcode
            generator.Save("generate-barcode.png");


            MemoryStream stream = new MemoryStream();
            
            //    generator.Save(stream, SaveFormat.png;
            //generator.Save(stream);
            byte[] data = stream.ToArray();
           


        }
        [AllowAnonymous]

        public IActionResult Labels(int id)
        {
            return View();

        }
        public IActionResult delete_invoice(int id)
        {
            var x = _context.Invoices.FirstOrDefault(x => x.id == id);
            _context.Remove(x);
            _context.SaveChanges();
            res("Invoice deleted successfully ", "success", "Success!");

            return RedirectToAction("home_details", "system_two", new
            {
                id = id,

            });

        }
        [Authorize]

        public IActionResult add_invoice(int lpo, string date, String ms, int id, int d_no)
        {
            Invoices x = new Invoices();
            x.LPO_Number = lpo;
            x.date = date;
            x.Delivery_no = d_no;
            x.M_s = ms;
            x.client_id = id;
            _context.Add(x);
            _context.SaveChanges();
            res("Invoice generated successfully ", "success", "Success!");

            return RedirectToAction("home_details", "system_two", new
            {
                id = id,

            });
        }
        [Authorize]

        public IActionResult add_delivery(int lpo, string received_by, string delivered_by, string date, String ms, int id, int d_number)
        {
            Deliveries x = new Deliveries();
            x.LPO_Number = lpo;
            x.date = date;
            x.M_s = ms;
            x.client_id = id;
            x.Received_by = received_by;
            x.Delivered_by = delivered_by;
            x.D_Number = d_number;
            _context.Add(x);
            _context.SaveChanges();
            res("Delivery note generated successfully ", "success", "Success!");

            return RedirectToAction("home_details", "system_two", new
            {
                id = id,

            });
        }
        [Authorize]

        public IActionResult delete_client(int id)
        {
            var client = _context.Clients.FirstOrDefault(x => x.id == id);
            var name = client.Client_name;
            _context.Remove(client);
            _context.SaveChanges();
            res("Client removed successfully from the system.", "success", name);
            return Redirect("~/system_two/home");


        }
        [Authorize]

        public IActionResult del_delivery(int id)
        {
            var x = _context.Deliveries.FirstOrDefault(x => x.id == id);
            var j = _context.Particulars.Where(x => x.delivery_no == id);


            float SUM = _context.Particulars.Where(x => x.delivery_no == id)
  .Select(x => x.total) // We only need one field, not the whole user object.
  .ToArray() // Run the SQL and bring over the array of short/byte
  .Sum();

            var client = x.client_id;
            var z = _context.Clients.FirstOrDefault(x => x.id == client);
            z.account_balance = z.account_balance - SUM;
            _context.Entry(z).State = EntityState.Modified;

            _context.RemoveRange(j);
            _context.Remove(x);
            _context.SaveChanges();
            res("Delivery note deleted successfully!", "success", "Success!");

            return RedirectToAction("home_details", "system_two", new
            {
                id = client

            });


        }
        [AllowAnonymous]
        public IActionResult infor(int id)
        {
            ViewModels view = new ViewModels();
            view.Deliveries = _context.Deliveries.FirstOrDefault(x => x.id == id);
            view.Particulars = _context.Particulars.Where(x => x.delivery_no == id);
            ViewBag.sum = _context.Particulars.Where(x => x.delivery_no == id)
   .Select(x => x.total) // We only need one field, not the whole user object.
   .ToArray() // Run the SQL and bring over the array of short/byte
   .Sum();


            return View(view);

        
        }
        [Authorize]

        public IActionResult delete_item(int id, int c_id, int d_id)
        {
            var client = _context.Particulars.FirstOrDefault(x => x.id == id);

            var v = _context.Deliveries.FirstOrDefault(x => x.id == d_id);
            v.Total = v.Total - client.total;
            float b = client.total;
            _context.Entry(v).State = EntityState.Modified;
            _context.SaveChanges();

            var z = _context.Clients.FirstOrDefault(x => x.id == c_id);
            z.account_balance = z.account_balance - b;
            _context.Entry(z).State = EntityState.Modified;
            _context.SaveChanges();


            _context.Remove(client);
            _context.SaveChanges();
            res("Item removed successfully .", "success", "Success!");

            return RedirectToAction("deliveries", "system_two", new
            {
                id = d_id,

            });


        }
        [Authorize]

        public IActionResult delete_receipt(int id)
        {
            var client = _context.Receipts.FirstOrDefault(x => x.id == id);

            _context.Remove(client);
            _context.SaveChanges();
            res("Receipt removed successfully.", "success", "Success!");

            return RedirectToAction("home_details", "system_two", new
            {
                id = id,

            });


        }
        [Authorize]

        public IActionResult deliveries(int id)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://www.supremesai.co.ke/system_two/infor/" + id,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ViewBag.qr_code = BitmapToBytes(qrCodeImage);


            ViewBag.particulars = _context.Particulars.Where(x => x.delivery_no == id);
            ViewBag.id = id;
            ViewBag.lpo = _context.Deliveries.FirstOrDefault(x => x.id == id).LPO_Number;
            ViewBag.ms = _context.Deliveries.FirstOrDefault(x => x.id == id).M_s;
            ViewBag.d_no = _context.Deliveries.FirstOrDefault(x => x.id == id).D_Number;
            ViewBag.received = _context.Deliveries.FirstOrDefault(x => x.id == id).Received_by;

            ViewBag.sum = _context.Particulars.Where(x => x.delivery_no == id)
    .Select(x => x.total) // We only need one field, not the whole user object.
    .ToArray() // Run the SQL and bring over the array of short/byte
    .Sum();

            var x = _context.Deliveries.FirstOrDefault(x => x.id == id);
            ViewBag.particulars = _context.Particulars.Where(x => x.delivery_no == id).ToList();
            ViewBag.date = x.date;

            return View(x);
        }
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]

        public IActionResult invoices(int id)
        {
            ViewBag.sum = _context.Particulars.Where(x => x.delivery_no == id)
           .Select(x => x.total) // We only need one field, not the whole user object.
           .ToArray() // Run the SQL and bring over the array of short/byte
           .Sum();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://www.supremesai.co.ke/system_two/infor/" + id,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            ViewBag.qr_code = BitmapToBytes(qrCodeImage);


            ViewBag.particulars = _context.Particulars.Where(x => x.delivery_no == id);
            ViewBag.id = id;
            ViewBag.lpo = _context.Deliveries.FirstOrDefault(x => x.id == id).LPO_Number;
            ViewBag.ms = _context.Deliveries.FirstOrDefault(x => x.id == id).M_s;
            ViewBag.d_no = _context.Deliveries.FirstOrDefault(x => x.id == id).D_Number;
            ViewBag.date = today;
            return View();
        }
        [Authorize]

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        [Authorize]

        public IActionResult receipts(int id)
        {
            
            var x = _context.Receipts.FirstOrDefault(x => x.id == id);
            ViewBag.date = today;
            return View(x);
        }
        [Authorize]
       
         public IActionResult home()
        {
            ViewBag.count = _context.Clients.Count();
            ViewBag.clients = _context.Clients.ToList();
           
            return View();
        }
        [Authorize]


        public IActionResult reset_pass()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult log_in()
        {
            return View();
        }
        [Authorize]

        public IActionResult select_category()
        {
            return View();
        }
        [Authorize]

        public IActionResult log_out()
        {
            HttpContext.Session.Clear();
            return Redirect("~/system_two/Category");
        }
        [Authorize]

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        [HttpPost]
        public IActionResult submit_client(string name, string date, string phone)
        {

            Clients x = new Clients();
            x.Client_name = name;
            x.date = date;
            x.Phone_number = phone;
            x.Password = "12345678";
            _context.Add(x);
            _context.SaveChanges();
            res("Client Added successfully to the system", "success", "Success!");

            return Redirect("~/system_two/home");

        }
        [Authorize]

        public IActionResult receipt(float cash_received, string date, int client, int cash, string ms, string item, string check)
        {



            var c = _context.Clients.FirstOrDefault(x => x.id == client);
            float i = c.account_balance;
            float j = i - cash_received;
            Receipts2 x = new Receipts2();
            x.Total = cash_received;
            x.Date = date;
            x.Particulars = item;
            x.client_id = client;
            x.Received_from = ms;
            x.Balance = j;

            if (cash == 1)
            {
                x.Payment_mode = true;
                x.check_number = check;
            }
            else
            {
                x.Payment_mode = false;
                x.check_number = "0";
            }

            _context.Add(x);
            _context.SaveChanges();

            c.account_balance = j;
            _context.Entry(x).State = EntityState.Modified;

            _context.SaveChanges();
            res("Payment recorded successfully to the system,Please go to the receipts tab and print.", "success", "Success!");

            return RedirectToAction("home_details", "system_two", new
            {
                id = client,

            });



        }
        [Authorize]

        public IActionResult add_particulars(int qnty, string name, int delivery_no, int client_id, int price, int id)
        {

            Particulars x = new Particulars();
            x.Item_name = name;
            x.delivery_no = id;
            x.Quantity = qnty;
            x.client_id = client_id;
            x.price = price;
            x.total = (price * qnty);


            _context.Add(x);
            _context.SaveChanges();


            var v = _context.Deliveries.FirstOrDefault(x => x.id == id);
            v.Total = v.Total + (price * qnty);
            _context.Entry(v).State = EntityState.Modified;
            _context.SaveChanges();

            var z = _context.Clients.FirstOrDefault(x => x.id == client_id);
            z.account_balance = z.account_balance + (price * qnty);
            _context.Entry(z).State = EntityState.Modified;
            _context.SaveChanges();
            res("Item added successfully to the system", "success", "Success!");




            return RedirectToAction("deliveries", "system_two", new
            {
                id = id,

            });



        }
        [Authorize]
        [HttpPost]
        public IActionResult modify_client(string name, string date, string phone, int id, float balance_)
        {

            var x = _context.Clients.FirstOrDefault(x => x.id == id);
            try
            {
                x.Client_name = name;
                x.date = date;
                x.Phone_number = phone;
                x.Password = "12345678";
                x.account_balance = balance_;
                _context.Entry(x).State = EntityState.Modified;

                _context.SaveChanges();
                res("Client details modified successfully.", "success", "Success!");

            }
            catch
            {
                res("Something went wrong", "error", "Failed!");

            }


            return Redirect("~/system_two/home");

        }
        [Authorize]

        public IActionResult modify_bal(int id, float balance_)
        {

            var x = _context.Clients.FirstOrDefault(x => x.id == id);
            try
            {

                x.account_balance = balance_;
                _context.Entry(x).State = EntityState.Modified;

                _context.SaveChanges();
                res("Balance  modified successfully.", "success", "Success!");

            }
            catch
            {
                res("Something went wrong", "error", "Failed!");

            }

            return RedirectToAction("home_details", "system_two", new
            {
                id = id,

            });


        }
        [Authorize]

        void res(string message, string type, string header)
        {
            TempData["message"] = message;
            TempData["type"] = "success";
            TempData["header"] = "Success!";
        }
        [AllowAnonymous]
        public IActionResult Log_in_user(int id, string password)
        {
            string pass = password;
            TokenProvider2 TokenProviderr = new TokenProvider2(_context);
            string userToken = TokenProviderr.LoginUser(id, password);
            if (userToken == null)
            {
                base.TempData["Error"] = "Invalid login credentials";
                TempData["message"] = "Invalid User ID or Password please check.";
                return Redirect("~/system_two/log_in");
            }
            HttpContext.Session.SetString("JWToken", userToken);

            HttpContext.Session.SetString("user_id", id.ToString());

            return Redirect("~/system_two/home");
        }

    }
}

