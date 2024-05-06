using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Models;
using TaskManagement.Models.ViewModel;
using TaskManagement.Repository.Interface;
using TaskManagement.Repository.Services;

namespace TaskManagement.Controllers.LoginSignup
{
    public class LoginSignupController : Controller
    {
        IUserPanelInterface _userPanel = new UserPanelService();
        
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

        [HttpPost]
        public ActionResult RegistrationPage(SignupCustomModel signup)
        {
            try
            {
                if (_userPanel.Signup(signup) == true)
                {
                    return View("Index");
                }
                else
                {
                    return View();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}