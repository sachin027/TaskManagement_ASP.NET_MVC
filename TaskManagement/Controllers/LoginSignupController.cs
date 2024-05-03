using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagement.Controllers.LoginSignup
{
    public class LoginSignupController : Controller
    {
        // GET: LoginSignup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View();
        }
    }
}