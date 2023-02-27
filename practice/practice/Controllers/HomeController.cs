using Microsoft.AspNetCore.Mvc;
using practice.Models;
using System.Diagnostics;
using prac1.Entities.DataModels;


namespace practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data _db;

        public HomeController(ILogger<HomeController> logger,Data db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult form()
        {
            return View();
        }

        //public IActionResult submitted()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Form(string Email, string Password)
        //{
        //    //var name = "abc";
        //    //var pass = "123";
        //    var user = _db.Logins.FirstOrDefault(x => x.Email == Email);
        //    if (user == null)
        //    {
        //        //TempData['error']="error in email;
        //    }
        //    else if(user.Password == Password)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("form");
        //    }
        //}

        [HttpPost]
        public IActionResult Submitted(string Email, string Password)
        {
            //var name = "abc";
            //var pass = "123";
            var user = _db.Logins.FirstOrDefault(x => x.Email == Email);

            if (user == null)
            {
                return RedirectToAction("form");
            }
            else if (user.Password == Password)
            {
                return View("submitted");
            }
            else
            {
                return RedirectToAction("form");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}