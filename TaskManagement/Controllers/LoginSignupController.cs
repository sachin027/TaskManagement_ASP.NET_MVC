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
        public ActionResult Index([Bind(Include ="Role ,Username , Password")] SignupCustomModel login)
        {
            try
            {
                if (_userPanel.Login(login))
                {
                    if(login.Role == "Student") { 
                        return RedirectToAction("RegistrationPage","LoginSignup");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "LoginSignup");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
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