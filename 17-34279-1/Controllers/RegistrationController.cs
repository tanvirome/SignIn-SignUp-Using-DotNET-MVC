using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _17_34279_1.Controllers
{
    public class user
    {
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string gender { get; set; }
        public string day { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user u)
        {
            string name = u.name;
            string username = u.username;
            string email = u.email;
            string password = u.password;
            string confirmPass = u.confirmPassword;
            string gender = u.gender;
            string day = u.day;
            string month = u.month;
            string year = u.year;
            string dob = day + ", " + month + ", " + year;

            if(System.Text.RegularExpressions.Regex.IsMatch(name, "^[a-zA-Z\\s]+$"))
            {
                if (password == confirmPass)
                {
                    Session["name"] = name;
                    Session["username"] = username;
                    Session["email"] = email;
                    Session["password"] = password;
                    Session["gender"] = gender;
                    Session["dob"] = dob;

                    return RedirectToAction("index", "Home");
                }
                else
                {
                    TempData["pass_error"] = "Password not match";
                    return View();
                }
            }
            else
            {
                TempData["name_error"] = "Invalid Name";
                return View();
            }
            
        }
    }
}