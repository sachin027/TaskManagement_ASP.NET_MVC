using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Models;

namespace TaskManagement.Controllers.LoginSignup
{
    public class LoginSignupController : Controller
    {
        // GET: LoginSignup
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Index(LoginDetailsModel loginDetails)
        {
            string name = "";
            if (loginDetails.UserRole == "Student")
            {
                name = "Student";
            }
            else
            {
                name = "Teacher";
            }
            return name;
        }
        public ActionResult RegistrationPage()
        {
            return View();
        }
    }
}