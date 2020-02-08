using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17_34279_1.Controllers
{
    public class login_user
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(login_user u)
        {
            string username = Session["username"].ToString();
            string password = Session["password"].ToString();
            if (u.username == username)
            {
                if(u.password == password)
                {
                    return RedirectToAction("Index", "HomePage");
                }
                else
                {
                    TempData["login_error"] = "Username or Password not match.";
                    return View();
                }
            }
            else
            {
                TempData["login_error"] = "Username or Password not match.";
                return View();
            }
        }
    }
}